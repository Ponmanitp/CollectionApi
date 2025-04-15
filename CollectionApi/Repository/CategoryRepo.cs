using CollectionApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CollectionApi.Repository
{
    public class CategoryRepo(ApplicationDBContext dbContext)
    {
        public async Task<List<Category>> GetCategoryList() 
            => await dbContext.Categories.ToListAsync();

        public async Task<Category?> GetCategoryByName(string name) 
            => await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);

        public async Task<Category?> AddCategory(Category category)
        {
            var existing = await GetCategoryByName(category.CategoryName)
                ?? throw new BadHttpRequestException("Category already exists");
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async void DeleteCategory(string name)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.CategoryName == name)
                ?? throw new BadHttpRequestException("Category not found");
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
        }
    }
}
