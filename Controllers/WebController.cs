using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("shohruzinha_gmail_com")] 
    public class MathController : ControllerBase
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
                long t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private long LCM(long a, long b)
        {
            return a / GCD(a, b) * b;
        }
    }
}
