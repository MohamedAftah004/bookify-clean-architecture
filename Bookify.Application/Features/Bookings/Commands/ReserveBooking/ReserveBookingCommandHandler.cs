using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Exceptions;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.ReserveBooking;

public class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{

    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRespository;
    private readonly IBookingRespository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;
    private readonly IDateTimeProvider _dateTimeProvider;


    public ReserveBookingCommandHandler(IUserRepository userRepository,
        IApartmentRepository apartmentRespository,
        IBookingRespository bookingRepository,
        IUnitOfWork unitOfWork,
        PricingService pricingServices,
        IDateTimeProvider dateTimeProvider
        )
    {
        _userRepository = userRepository;
        _apartmentRespository = apartmentRespository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingServices;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId , cancellationToken);
        if(user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var apartment = await _apartmentRespository.GetByIdAsync(request.ApartmentId, cancellationToken);
        if (apartment is null)
        {
            return Result.Failure<Guid>(ApartmentErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if(await _bookingRepository.IsOverlappingAsync(apartment , duration , cancellationToken))
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }


        try
        {
            var booking = Booking.Reserve(
            apartment,
            user.Id,
            duration,
            _dateTimeProvider.UtcNow,
            _pricingService
            );

            _bookingRepository.Add(booking);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return booking.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

    }
}
