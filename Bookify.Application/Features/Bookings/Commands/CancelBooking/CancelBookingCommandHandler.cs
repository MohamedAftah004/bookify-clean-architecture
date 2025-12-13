using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.CancelBooking
{
    internal sealed class CancelBookingCommandHandler : ICommandHandler<CancelBookingCommand>
    {

        private readonly IBookingRespository _bookingRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CancelBookingCommandHandler(
            IBookingRespository bookingRespository, 
            IUnitOfWork unitOfWork, 
            IDateTimeProvider dateTimeProvider)
        {
            _bookingRespository = bookingRespository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRespository.GetByIdAsync(request.BookingId);
            if(booking is null)
            {
                return Result.Failure(BookingErrors.NotFound);
            }

            var result = booking.Cancel(_dateTimeProvider.UtcNow);
            if (result.IsFailure)
            {
                return result;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
