
namespace WebApplication1.Models;

public class Product{

    public int ProductId {get;set;}
    public required string ProductName {get;set;}
    public required string ProductCatagory {get;set;}
    public int Price {get;set;}
    public int Cost {get;set;}

    public required string Description {get;set;}

}

