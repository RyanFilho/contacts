using Core.Models;
using Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // TODO: Add API Authentication and Authorization
    // [Authorize]
    public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfileModel>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("{adObjId}")]
    public async Task<ActionResult<UserProfileModel>> GetUserByAdObjId(int adObjId)
    {
        var user = await _userService.GetUserByIdAsync(adObjId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> AddUser(UserProfileModel userModel)
    {
        if(_userService.GetUserByAdObjIdAsync(userModel.AdObjId) == null) {
            await _userService.AddUserAsync(userModel);
            return CreatedAtAction(nameof(GetUserById), new { id = userModel.UserId }, userModel);
        }
        return Conflict();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, UserProfileModel userModel)
    {
        if (id != userModel.UserId)
        {
            return BadRequest();
        }

        await _userService.UpdateUserAsync(userModel);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}

}
