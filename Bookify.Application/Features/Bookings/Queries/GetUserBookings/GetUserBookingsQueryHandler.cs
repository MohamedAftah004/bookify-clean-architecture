using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Features.Bookings.Queries.GetUserBookings;

internal sealed class GetUserBookingsQueryHandler
    : IQueryHandler<GetUserBookingsQuery, IReadOnlyList<BookingSummaryResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUserBookingsQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<BookingSummaryResponse>>> Handle(
        GetUserBookingsQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS BookingId,
                apartment_id AS ApartmentId,
                duration_start AS StartDate,
                duration_end AS EndDate,
                status AS Status,
                total_price_amount AS TotalPrice,
                total_price_currency AS Currency
            FROM bookings
            WHERE user_id = @UserId
            ORDER BY created_on_utc DESC
            """;

        var bookings = await connection.QueryAsync<BookingSummaryResponse>(
            sql,
            new { request.UserId });

        return bookings.ToList();
    }
}
