



using WebApplication1.Models;

namespace WebApplication1.Services.Interface;
public interface IProductService {
    
    public List<Product> GetAllProduct();
    public Product? FindById(int id);

}