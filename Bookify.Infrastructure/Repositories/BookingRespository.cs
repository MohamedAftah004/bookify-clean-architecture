using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class BookingRespository : Repository<Booking>, IBookingRespository
    {

        private static readonly BookingStatus[] ActiveBookingStatuses =
        {
            BookingStatus.Reserved,
            BookingStatus.Confirmed,
            BookingStatus.Completed,
        };

        public BookingRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlappingAsync(
            Apartment apartment,
            DateRange duration, 
            CancellationToken cancellationToken = default)
        {

            return await DbContext
                .Set<Booking>()
                .AnyAsync(
                booking =>
                    booking.ApartmentId == apartment.Id &&
                    booking.Duration.Start <= duration.End &&
                    booking.Duration.End >= duration.Start &&
                    ActiveBookingStatuses.Contains(booking.Status),
                    cancellationToken);
        
        }
    }
}
