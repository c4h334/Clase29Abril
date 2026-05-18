using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Facade;
using StoreBackend.Models.Requests;

namespace StoreBackend.Controllers;

[ApiController]
// [EnableRateLimiting("Fixed")]
[Route("api/authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationFacade authorizationService;

    public AuthorizationController(IAuthorizationFacade authorizationFacade)
    {
        this.authorizationService = authorizationFacade;
    }

    [HttpPost("authorize")]
    public async Task<IActionResult> Authorize([FromBody] AuthorizationRequestModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var requestDto = AuthorizationMapper.ToDto(request);

        var result = await authorizationService.AuthorizeAsync(requestDto).ConfigureAwait(false);

        return Ok(AuthorizationMapper.ToResponse(result));
    }
}