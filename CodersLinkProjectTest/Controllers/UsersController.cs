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
            if(result != null)
                return Ok(result);
            return NotFound();

        }

        [HttpPost, Route("Create")]
        public IActionResult Create([FromForm] User user)
        {
            //TempData["UserModel"] = user;
            var result = _userManager.CreateUser(user);
            
            if(result == true)
                return Ok();
            return BadRequest();

        }
    }
}