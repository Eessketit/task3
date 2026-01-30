using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Linq;

namespace webproject.Controllers
{
    [ApiController]
    [Route("shohruzinha_gmail_com")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
        {
            if (!IsNatural(x) || !IsNatural(y))
                return Plain("NaN");

            BigInteger a = BigInteger.Parse(x!);
            BigInteger b = BigInteger.Parse(y!);

            BigInteger lcm = BigInteger.Abs(a * b) / GCD(a, b);
            return Plain(lcm.ToString());
        }

        private static bool IsNatural(string? s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            return s.All(char.IsDigit) && BigInteger.Parse(s) > 0;
        }

        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private static ContentResult Plain(string value) =>
            new ContentResult
            {
                Content = value,
                ContentType = "text/plain",
                StatusCode = 200
            };
    }
}
