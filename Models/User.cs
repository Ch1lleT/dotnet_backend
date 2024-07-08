
namespace WebApplication1.Models;

public class User {
    
    public  int id {get;set;}
    public  required string name {get;set;} 
    public  required string email {get;set;}
    public  required string password {get;set;}
    public  required string password_salt{get;set;}

    

}