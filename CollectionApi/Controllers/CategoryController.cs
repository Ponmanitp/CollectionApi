using CollectionApi.Models;
using CollectionApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApi.Controllers;

[Route(PathController)]
public class CategoryController( CategoryRepo categoryRepo) : RootController
{
    [HttpGet(Name = nameof(GetAllCategoriesAsync))]
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var categories = await categoryRepo.GetCategoryList();
        return categories;
    }

    [HttpPost(Name = nameof(AddCategoryAsync))]
    public async Task<Category> AddCategoryAsync(Category category)
    {
        var addCategory = await categoryRepo.AddCategory(category)
                ?? throw new KeyNotFoundException("Category not found");
        return addCategory;
    }

    [HttpGet("{name}", Name = nameof(GetCategoryByNameAsync))]
    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var category = await categoryRepo.GetCategoryByName(name)
                ?? throw new KeyNotFoundException("Category not found");
        return category;
    }

    [HttpDelete("{name}", Name = nameof(DeleteCategoryAsync))]
    public async Task DeleteCategoryAsync(string name)
    {
        var deleteCategory = await categoryRepo.GetCategoryByName(name)
                ?? throw new KeyNotFoundException("Category not found");
        categoryRepo.DeleteCategory(deleteCategory.CategoryName);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
