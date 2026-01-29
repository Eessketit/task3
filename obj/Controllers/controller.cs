using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("shohruzinha_gmail_com")]
public class LcmController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
    {
        if (!long.TryParse(x, out var a) ||
            !long.TryParse(y, out var b) ||
            a <= 0 || b <= 0)
        {
            return Content("NaN", "text/plain");
        }

        long lcm = a / Gcd(a, b) * b;
        return Content(lcm.ToString(), "text/plain");
    }

    private static long Gcd(long a, long b)
    {
        while (b != 0)
            (a, b) = (b, a % b);
        return a;
    }
}
