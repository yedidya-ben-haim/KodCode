using ECommerceApi.Model;
using ECommerceApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }
    
    //GET api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        return Ok(await _repository.GetAllWithCategoryAsync());
    }
    
    //GET api/products/search
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Product>>> Search(
        [FromQuery] string? searchTerm, [FromQuery] int? categoryId,
        [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
    {
        return Ok(await _repository.SearchAsync(searchTerm, categoryId, minPrice, maxPrice));
    }
    
    //GET api/products/sorted
    [HttpGet("sorted")]
    public async Task<ActionResult<IEnumerable<Product>>> Sorted(
        [FromQuery] string? sortBy, [FromQuery] bool descending = false)
    {
        return Ok(await _repository.GetSortedAsync(sortBy, descending));
    }
    
    //GET api/products/ratings
    [HttpGet("ratings")]
    public async Task<ActionResult<IEnumerable<Product>>> Ratings()
    {
        return Ok(await _repository.GetProductRatingsAsync());
    }
    
    //GET api/products/count-by-category
    [HttpGet("count-by-category")]
    public async Task<ActionResult<IEnumerable<Product>>> CountByCategory()
    {
        return Ok(await _repository.GetProductCountByCategoryAsync());
    }
    
    //GET api/products/count-by-category
    [HttpGet("paged")]
    public async Task<ActionResult<IEnumerable<Product>>> GetPaged(
        [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (products, totalCount) = await _repository.GetPagedAsync(page, pageSize);
        Console.WriteLine("hi");
        return Ok(new { products, totalCount, page, pageSize });
    }
    
}