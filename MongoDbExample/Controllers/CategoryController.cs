using Microsoft.AspNetCore.Mvc;
using MongoDbExample.DTO;
using MongoDbExample.Entities;
using MongoDbExample.Repositories;
using MongoDbExample.Services;

namespace MongoDbExample.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpPost("CreateCategory")]
    public IActionResult Create(CreateCategoryDto model)
    {
        try
        {
            _categoryService.Create(new Category()
            {
                Name = model.Name,
            });
            return Ok("Success");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllCategory")]
    public IActionResult Get()
    {
        try
        {
            var data = _categoryService.Get();
            return Ok(new { result = "Success", data = data });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("GetCategoryById/{id}")]
    public IActionResult GetCategoryById(string id)
    {
        try
        {
          
            return Ok(new { result = "Success", data = _categoryService.Get(id) });
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }


    [HttpPut("UpdateCategory")]
    public IActionResult UpdateCategory(Category model)
    {
        try
        {
            _categoryService.Update(model,model.Id);
            return Ok("Success");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteCategory/{id}")]
    public IActionResult DeleteCategory(string id)
    {
        try
        {
            _categoryService.Delete(id);
            return Ok("Success");
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}