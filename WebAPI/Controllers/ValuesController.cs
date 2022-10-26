using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IYoneticiService _yoneticiService;

        public AuthController(IYoneticiService yoneticiService)
        {
            _yoneticiService = yoneticiService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _yoneticiService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Login")]
        public IActionResult Login(string user,string pwd )
        {
            var result = _yoneticiService.Auth(user,pwd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
