using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        IUserOpeartionClaimService _userOpeartionClaimService;
        public UserOperationClaimsController(IUserOpeartionClaimService userOpeartionClaimService)
        {
            _userOpeartionClaimService = userOpeartionClaimService;
        }

        [HttpPost("addUserOperationClaim")]
        public IActionResult addUserOperationClaim(UserOperationClaim claim)
        {
            var result = _userOpeartionClaimService.Add(claim);
            if (result.Success)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("deleteUserOperationClaim")]
        public IActionResult deleteUserOperationClaim(UserOperationClaim claim)
        {
            var result = _userOpeartionClaimService.Delete(claim);
            if (result.Success)
                return Ok();
            return BadRequest();
        }
    }
}
