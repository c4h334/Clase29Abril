using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Security;
using StoreBackend.DomainService;
using StoreBackend.Facade;

namespace StoreBackend.Api.Controllers
{
    //[Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserFacade userFacade) : ControllerBase
    {
        [Authorize(Policy = AuthorizationPolicies.CanSearchUsers)]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var users = await userFacade.GetAllAsync();
            var models = UserMapper.ToModel(users);

            return Ok(models);
        }

        //[Authorize(Roles = RoleNames.Administrator)]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestModel user)
        {
            var requestDto = UserMapper.ToDto(user);
            var userDto = await userFacade.CreateAsync(requestDto);
            var userModel = UserMapper.ToModel(userDto);
            return Ok(userModel);
        }

        // [Authorize(Roles = RoleNames.Administrator)]
        [HttpGet("{userId}/roles")]
        public async Task<IActionResult> GetUserRolesAsync(Guid userId)
        {
            var userRoles = await userFacade.GetUserRolesAsync(userId);
            var responseModel = UserMapper.ToUserRolesResponseModel(userRoles);
            return Ok(responseModel);
        }

        // [Authorize(Roles = RoleNames.Administrator)]
        [HttpPut("{userId}/roles")]
        public async Task<IActionResult> UpdateUserRolesAsync(Guid userId, [FromBody] UpdateRolesRequestModel model)
        {
            var requestDto = UserMapper.ToDto(model);
            var userRoles = await userFacade.UpdateUserRolesAsync(userId, requestDto);
            var responseModel = UserMapper.ToUserRolesResponseModel(userRoles);
            return Ok(responseModel);
        }

        // [Authorize(Roles = RoleNames.Administrator)]
        [HttpDelete("{userId}/roles")]
        public async Task<IActionResult> DeleteUserRolesAsync(Guid userId)
        {

            await userFacade.DeleteUserRolesAsync(userId);
            return Ok();
        }
    }
}