using Microsoft.AspNetCore.Mvc;

namespace webproject.Controllers
{
    [ApiController]
    [Route("shohruzinha_gmail_com")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            [FromQuery] string? x,
            [FromQuery] string? y)
        {
            if (!long.TryParse(x, out long a) ||
                !long.TryParse(y, out long b) ||
                a <= 0 || b <= 0)
            {
                return Content("NaN", "text/plain");
            }

            long lcm = LCM(a, b);
            return Content(lcm.ToString(), "text/plain");
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private long LCM(long a, long b)
        {
            return a / GCD(a, b) * b;
        }
    }
}
