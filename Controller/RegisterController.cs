
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Resource;
using WebApplication1.Services;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers;


[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase{

    private IUserService _userservice;

    public RegisterController(IUserService userservice) : base() {
        this._userservice = userservice;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Index(RegisterResource user){
        User new_user;
        
        try
        {
            new_user = await _userservice.Register(user);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }

        var return_user = new {
            userId = new_user.id,
            email = new_user.email,
        };

        return CreatedAtAction(nameof(Index), new {userId = new_user.id , email = new_user.email}, return_user);
    }

}