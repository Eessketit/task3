using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/shohruzinha_gmail_com", (string? x, string? y) =>
{
    if (!IsNatural(x) || !IsNatural(y))
        return Results.Text("NaN", "text/plain");

    BigInteger bx = BigInteger.Parse(x!);
    BigInteger by = BigInteger.Parse(y!);

    BigInteger lcm = Lcm(bx, by);
    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();

static bool IsNatural(string? s)
{
    if (string.IsNullOrWhiteSpace(s))
        return false;

    if (!BigInteger.TryParse(s, out var n))
        return false;

    return n > 0;
}

static BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        var t = b;
        b = a % b;
        a = t;
    }
    return a;
}

static BigInteger Lcm(BigInteger a, BigInteger b)
{
    return (a / Gcd(a, b)) * b;
}
