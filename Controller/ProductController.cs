using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controller;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase {

    private readonly IProductService _productservice;

    public ProductController(IProductService productservice) : base() {
        this._productservice = productservice;
    }

    [HttpGet]
    public ActionResult Index(){
        
        var Products = this._productservice.GetAllProduct();
        return Products.Count != 0 ?  Ok(new { products = Products}) : NoContent();
    }

    [HttpGet("{id}")]
    public ActionResult Index(int id)
    {

        var product = this._productservice.FindById(id);
        return product != null ? Ok(new {product = product}) :  NoContent();

    }

    
}