using WebApplication1.Db;
using WebApplication1.Models;
using WebApplication1.Resource;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services;


public class UserService : IUserService
{   

    private readonly DatabaseContext _context;

    public UserService(DatabaseContext context)
    {
        this._context = context;
    }


    public User Login(LoginResource User)
    {
        User? RealUser = _context.Users.FirstOrDefault(e => e.email == User.Email) ?? throw new Exception("Email or password not correct.");

        // Comparehash
        var hashed_result = PasswordHasher.ComputeHash(User.Password, RealUser.password_salt, 3 );
        
        return hashed_result == RealUser.password ? RealUser : throw new Exception("Email or password not correct.");
    }


    public async Task<User> Register(RegisterResource Register)
    {
        
        int maxId = _context.Users.Any() ? _context.Users.Max(e => e.id) : 0;

        var user = _context.Users.FirstOrDefault(e=>e.email == Register.Email);
        
        if(user != null){
            throw new Exception("The email already used.");
        }

        var salt = PasswordHasher.GenerateSalt();

        var hashedpwd = PasswordHasher.ComputeHash(Register.Password,salt,3);

        var new_user = new User{
            id = maxId+ 1,
            email = Register.Email,
            name = Register.Name,
            password = hashedpwd,
            password_salt = salt, 
        } ;

        _context.Add(new_user);
        await _context.SaveChangesAsync();
        
        return new_user; 
    }

    
    
}