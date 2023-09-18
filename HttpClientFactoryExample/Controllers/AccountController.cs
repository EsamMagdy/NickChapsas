using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
      

        [HttpGet("LoadAccount")]
        public async Task<ActionResult> LoadAccount()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com/"),
                DefaultRequestHeaders =
                {
                    {"Accept","application/vnd.github.v3+json" },
                    {"User-Agent","HttpClientFactoryExample" }
                }
            };

            var accountInfo = await httpClient.GetStringAsync("users/EsamMagdy");

            return Ok(accountInfo);
        }
    }
}
