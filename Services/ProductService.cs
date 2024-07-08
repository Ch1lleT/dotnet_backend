
using WebApplication1.Db;
using WebApplication1.Models;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services;

public class ProductService : IProductService{

    private DatabaseContext _context ;
    public ProductService(DatabaseContext context){
        this._context = context;
    }

    public Product? FindById(int id)
    {
        return _context.Products.Find(id);
    }

    public List<Product> GetAllProduct()
    {

        List<Product> products = [.. _context.Products];
        return products;
    }
}