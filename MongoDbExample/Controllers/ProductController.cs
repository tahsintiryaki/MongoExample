using Microsoft.AspNetCore.Mvc;
using MongoDbExample.DTO;
using MongoDbExample.Entities;
using MongoDbExample.Services;

namespace MongoDbExample.Controllers;

public class ProductController : Controller
{
    private readonly IProductDetailService _productDetailService;

    public ProductController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet("GetAllProducts")]
    public IActionResult GetAllProducts()
    {
        var result = _productDetailService.Get();
        return Ok(new { result = "Success", data = result });
    }
    [HttpPost("CreateProduct")]
    public IActionResult CreateSample(CreateProductDetailDto model)
    {
        try
        {
            
            _productDetailService.Create(new ProductDetails()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock
            });
            return Ok("Success");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    
    [HttpGet("GetProductById/{id}")]
    public IActionResult GetProductById(string id)
    {
        try
        {
           var product = _productDetailService.Get(id);
            return Ok(new { result = "Success", data = product });
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }


    [HttpPut("UpdateProduct")]
    public IActionResult UpdateProduct(ProductDetails model)
    {
        try
        {
            _productDetailService.Update(model,model.Id);
            return Ok("Success");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteProduct/{id}")]
    public IActionResult DeleteProduct(string id)
    {
        try
        {
            _productDetailService.Delete(id);
            return Ok("Success");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}