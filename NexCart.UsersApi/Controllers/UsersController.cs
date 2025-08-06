using Microsoft.AspNetCore.Mvc;
using NexCart.Users.DTO;
using NexCart.Users.ServiceContracts;

namespace NexCart.UsersApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpGet("{userID}")]
    public async Task<IActionResult> GetUserByUserID(Guid userID)
    {
        if (userID == Guid.Empty)
        {
            return BadRequest("Invalid user ID");
        }
        UserDTO? user = await _usersService.GetUserByUserID(userID);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return Ok(user);
    }

}