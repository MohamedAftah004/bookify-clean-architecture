namespace Bookify.Application.Features.Bookings.Queries.GetUserBookings;

public sealed class BookingSummaryResponse
{
    public Guid BookingId { get; init; }
    public Guid ApartmentId { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public decimal TotalPrice { get; init; }
    public string Currency { get; init; } = string.Empty;
}
