

using WebApplication1.Models;
using WebApplication1.Resource;

namespace WebApplication1.Services.Interface;
public interface IUserService {
    
    public User Login(LoginResource User);
    public Task<User> Register(RegisterResource Register);

}