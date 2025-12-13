using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

public static class ApartmentErrors
{
    public static readonly Error NotFound = new(
        "Apartment.NotFound",
        "The apartment with the specified identifier was not found");

    public static readonly Error Unavailable = new(
        "Apartment.Unavailable",
        "The apartment is not available for the requested period");

    public static readonly Error OverlappingBooking = new(
        "Apartment.OverlappingBooking",
        "The requested booking overlaps with an existing booking for this apartment");

    public static readonly Error InvalidPrice = new(
        "Apartment.InvalidPrice",
        "The apartment price or pricing details are invalid");

    public static readonly Error InvalidAddress = new(
        "Apartment.InvalidAddress",
        "The provided address is not valid");

    public static readonly Error MaxOccupancyExceeded = new(
        "Apartment.MaxOccupancyExceeded",
        "The requested number of guests exceeds the apartment's maximum occupancy");

    public static readonly Error AmenityNotFound = new(
        "Apartment.AmenityNotFound",
        "One or more requested amenities are not available for this apartment");

    public static readonly Error HostNotFound = new(
        "Apartment.HostNotFound",
        "The host/owner for this apartment was not found");

    public static readonly Error CurrencyMismatch = new(
        "Apartment.CurrencyMismatch",
        "The pricing currency does not match the system or apartment currency");

    public static readonly Error InvalidName = new(
        "Apartment.InvalidName",
        "The apartment name is invalid or empty");
}
