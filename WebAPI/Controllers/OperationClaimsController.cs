using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet("getAllOperationClaims")]
        public IActionResult getAllOperationClaims() 
        {
            var result = _operationClaimService.GetAll();
            if(result.Success)
                return Ok(result.Data);
            return BadRequest();
        }
    }
}
