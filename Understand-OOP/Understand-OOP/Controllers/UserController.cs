using Microsoft.AspNetCore.Mvc;
using Understand_OOP.DTOs;
using Understand_OOP.IServ;
using Microsoft.Extensions.Logging;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userRequestDto)
    {
        if (userRequestDto == null)
        {
            _logger.LogWarning("Invalid user creation request.");
            return BadRequest("Invalid request data.");
        }

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid user creation request model state.");
            return BadRequest(ModelState);
        }

        try
        {
            bool isCreated = await _userService.CreateUser(userRequestDto);

            if (!isCreated)
            {
                _logger.LogWarning($"User {userRequestDto.Email} could not be created.");
                return BadRequest("User could not be created.");
            }

            _logger.LogInformation($"User {userRequestDto.Email} created successfully.");
            return Ok(new { message = "User created successfully!" });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in user creation: {ex.Message}");
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
