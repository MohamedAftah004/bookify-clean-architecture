using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.ConfirmBooking
{
    internal sealed class ConfirmBookingCommandHandler : ICommandHandler<ConfirmBookingCommand>
    {
        private readonly IBookingRespository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ConfirmBookingCommandHandler(
            IBookingRespository bookingRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }



        public async Task<Result> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
        {

            var booking = await _bookingRepository.GetByIdAsync(request.BookingId);

            if(booking is null)
            {
                return Result.Failure(BookingErrors.NotFound);
            }

            var result = booking.Confirm(_dateTimeProvider.UtcNow);

            if(result.IsFailure)
            {
                return result;
            }


            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
