using CollectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApi.Repository;

public class CategoryRepo(ApplicationDBContext dbContext)
{
    public async Task<List<Category>> GetCategoryList()
        => await dbContext.Categories.ToListAsync();

    public async Task<Category?> GetCategoryByName(string categoryName)
        => await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

    public async Task<Category?> AddCategory(Category category)
    {
        var existingCategory = await GetCategoryByName(category.CategoryName);
        if (existingCategory != null)
            throw new BadHttpRequestException("Category already exists");
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> EditCategory(Category category)
    {
        dbContext.Categories.Update(category);
        await dbContext.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategory(string categoryName)
    {
        var category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == categoryName)
            ?? throw new BadHttpRequestException("Category not found");
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
    }
}
