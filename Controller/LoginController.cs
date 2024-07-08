

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Resource;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controller;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase {

    private IUserService _userservice ; 
    private readonly IConfiguration _config;

    public LoginController(IUserService userservice ,IConfiguration config ) : base() {
        this._userservice = userservice; 
        this._config = config;
    }

    [HttpPost]
    public IActionResult Index(LoginResource User)
    {
        try
        {

            var user = _userservice.Login(User);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(1),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);


            return Ok(new { id = user.id, name = user.name, email = user.email, token = token });
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet("/test")]
    public ActionResult TestToken(){
        return Ok();
    }
}