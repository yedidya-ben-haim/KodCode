using ECommerceApi.Data;
using ECommerceApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ECommerceDbContext _context;

    public ProductRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Reviews)
            .ToListAsync();
    }

    public Task<IEnumerable<Category>> GetCategoriesWithFullTreeAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> SearchAsync(string? searchTerm, int? categoryId, decimal? minPrice, decimal? maxPrice)
    {
        var query = _context.Products.Include(p => p.Category).AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
            query = query.Where(p => p.Name.Contains(searchTerm));
        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);
        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);
        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetSortedAsync(string? sortBy, bool descending)
    {
        var query = _context.Products.AsQueryable();

        query = sortBy?.ToLower() switch
        {
            "price" => descending
                ? query.OrderByDescending(p => p.Price)
                : query.OrderBy(p => p.Price),
            "name" => descending
                ? query.OrderByDescending(p => p.Name)
                : query.OrderBy(p => p.Name),
            _ => query.OrderBy(p => p.Id)

        };
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<object>> GetProductRatingsAsync()
    {
        return await _context.Products.Select(p => new
        {
            p.Id,
            p.Name,
            ReviewCount = p.Reviews.Count,
            AverageRating = p.Reviews.Any() ? p.Reviews.Average(r => r.Rating) : 0
        }).ToListAsync();
    }

    public async Task<IEnumerable<object>> GetProductCountByCategoryAsync()
    {
        return await _context.Products
            .GroupBy(p => p.CategoryId)
            .Select(g => new
            {
                CategoryId = g.Key,
                ProductCount = g.Count()
            })
            .ToListAsync();
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetPagedAsync(int page, int pageSize)
    {
        var totalCount = await _context.Products.CountAsync();

        var products = await _context.Products
            .OrderBy(p => p.Id)
            .Skip((1 - page) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (products, totalCount);
    }
    
}