using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Understand_OOP.DTOs;
using Understand_OOP.IServ;
using Understand_OOP.Service;

namespace Understand_OOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;  

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Createuser(UserRequestDto userRequestDto)
        {
            try
            {
                var result = await _userService.CreateUser(userRequestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost("Login")]
        //public async Task<IActionResult> Login(LoginRegDto loginrequest)
        //{
        //    try
        //    {
        //        var data = await _userService.Login(loginrequest);
        //        return Ok(data);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet("AllUsers")]
        //public async Task<IActionResult> AllUsers()
        //{
        //    try
        //    {

        //        var data = await _userService.AllUsers();
        //        return Ok(data);

        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
