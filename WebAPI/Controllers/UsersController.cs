using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService) { 
            _userService = userService;
        }

        [HttpGet("getUserByID")]
        public IActionResult getUserByID(Guid id) { 
            var result=_userService.GetCompleteInfoById(id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
        [HttpGet("getAllUser")]
        public IActionResult getAllUser()
        {
            var result = _userService.GetAllCompleteInfo();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
    }
}
