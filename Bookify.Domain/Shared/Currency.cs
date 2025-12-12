namespace Bookify.Domain.Shared;
public record Currency
{

    internal static readonly Currency None= new("");
    public static readonly Currency USD = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency EGP = new("EGP");

    private Currency(string Code) => Code = Code;


    public string Code { get; init; }

    

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException($"Currency with code '{code}' is not supported.");
    }
    
    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        USD,
        Eur,
        EGP
    };


}
