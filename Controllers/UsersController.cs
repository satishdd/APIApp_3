using APIApp_3.Models;
using APIApp_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIApp_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(Register model)
        {
            _userService.Register(model);
            return Ok(new { message = "Success" });
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        [HttpPost("login")]
        public IActionResult Login(LoginRequest model)
        {
            _userService.Login(model);
            return Ok(new { message = "Success" });
        }

        [HttpGet("{email}")]
        public IActionResult GetByEmail(string email)
        {
            var uDeatails = _userService.GetByEmail(email);
            return Ok(uDeatails);
        }
    }
}
