using Microsoft.AspNetCore.Mvc;
using MongoDbExample.DTO;
using MongoDbExample.Entities;
using MongoDbExample.RedisCache.Interfaces;
using MongoDbExample.Repositories;
using MongoDbExample.Services;

namespace MongoDbExample.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IRedisCacheService _redisCache;
    public CategoryController(ICategoryService categoryService, IRedisCacheService redisCache)
    {
        _categoryService = categoryService;
        _redisCache = redisCache;
    }


    [HttpPost("CreateCategory")]
    public async Task<IActionResult> Create(CreateCategoryDto model)
    {
        try
        {
            await _categoryService.CreateCategoryandSetRedis(new Category()
            {
                Name = model.Name,
            },"Category");
           
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
            var data = _categoryService.GetCategoriesFromCache("Category");
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