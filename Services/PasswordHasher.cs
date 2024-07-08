using System.Security.Cryptography;
using System.Text;


namespace WebApplication1.Services;

public class PasswordHasher {

    

    public static string ComputeHash(string pwd,string salt , int iteration){
        
        if(iteration <= 0) return pwd;
        
        using var sha256 = SHA256.Create();

        var pwdsalt = $"{pwd}{salt}";
        var byteValue = Encoding.UTF8.GetBytes(pwdsalt);
        var byteHash = sha256.ComputeHash(byteValue);
        var hash = Convert.ToBase64String(byteHash);

        return ComputeHash(hash,salt,iteration-1);
    }


    public static string GenerateSalt()
    {
        using var rng = RandomNumberGenerator.Create();
        var byteSalt = new Byte[16];
        rng.GetBytes(byteSalt);
        var salt = Convert.ToBase64String(byteSalt);

        return salt;
    }
}