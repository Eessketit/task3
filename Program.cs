var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/shohruzinha_gmail_com", (string x, string y) =>
{
    if (!int.TryParse(x, out int a) || !int.TryParse(y, out int b))
        return Results.Text("NaN");

    if (a <= 0 || b <= 0)
        return Results.Text("NaN");

    long lcm = (long)a * b / Gcd(a, b);
    return Results.Text(lcm.ToString());
});

app.Run();

static int Gcd(int a, int b)
{
    while (b != 0)
    {
        int t = b;
        b = a % b;
        a = t;
    }
    return a;
}
