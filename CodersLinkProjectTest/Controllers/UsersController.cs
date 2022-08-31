using Domain.IManager;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        
        private readonly ILogger<UsersController> _logger;
        private readonly IUserManager _userManager;

        public UsersController(ILogger<UsersController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet, Route("")]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var result = await _userManager.GtAllUsers();
            return Ok(result);

        }

        [HttpPost, Route("Create")]
        public IActionResult Create([FromForm] User user)
        {
            //TempData["UserModel"] = user;
            var result = _userManager.CreateUser(user);
            
            return Ok();

        }
    }
}