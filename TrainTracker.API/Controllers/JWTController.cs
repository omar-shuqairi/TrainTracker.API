using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jWTService;

        public JWTController(IJWTService jWTService)
        {
            _jWTService = jWTService;
        }
        [HttpPost]
        public IActionResult Auth([FromBody] User user)
        {
            var token = _jWTService.Auth(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);

        }

    }
}
