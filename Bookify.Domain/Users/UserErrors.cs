using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFound = new(
        "User.NotFound",
        "The user with the specified identifier was not found");

    public static readonly Error EmailAlreadyInUse = new(
        "User.EmailAlreadyInUse",
        "The provided email address is already associated with another user");

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "The email or password is incorrect");

    public static readonly Error Inactive = new(
        "User.Inactive",
        "The user account is inactive");

    public static readonly Error Unauthorized = new(
        "User.Unauthorized",
        "The user is not authorized to perform this action");

    public static readonly Error InvalidEmailFormat = new(
        "User.InvalidEmailFormat",
        "The provided email address is not valid");

    public static readonly Error PasswordTooWeak = new(
        "User.PasswordTooWeak",
        "The provided password does not meet the minimum requirements");

    public static readonly Error AlreadyVerified = new(
        "User.AlreadyVerified",
        "The user account is already verified");

    public static readonly Error VerificationExpired = new(
        "User.VerificationExpired",
        "The verification code has expired");

    public static readonly Error DuplicateUser = new(
        "User.DuplicateUser",
        "A user with the same information already exists");
}
