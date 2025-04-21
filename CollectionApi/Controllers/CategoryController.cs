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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Category> AddCategoryAsync(Category category)
    {
        var addCategory = await categoryRepo.AddCategory(category)
                ?? throw new KeyNotFoundException("Category not found");
        return addCategory;
    }

    [HttpGet("{categoryName}", Name = nameof(GetCategoryByNameAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<Category> GetCategoryByNameAsync(string categoryName)
    {
        var category = await categoryRepo.GetCategoryByName(categoryName)
                ?? throw new KeyNotFoundException("Category not found");
        return category;
    }

    [HttpPut("{CategoryName}", Name = nameof(EditCategoryAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<Category> EditCategoryAsync([FromBody] Category category, string CategoryName)
    {
        var existingCategory = await categoryRepo.GetCategoryByName(CategoryName)
           ?? throw new KeyNotFoundException("Category not found");

        existingCategory.CategoryName = category.CategoryName;
        existingCategory.CategoryUrl = category.CategoryUrl;
        var updatedCategory = await categoryRepo.EditCategory(existingCategory)
            ?? throw new BadHttpRequestException("Unable to edit category");
        return updatedCategory;
    }

    [HttpDelete("{categoryName}", Name = nameof(DeleteCategoryAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeleteCategoryAsync(string categoryName)
    {
        var deleteCategory = await categoryRepo.GetCategoryByName(categoryName)
                ?? throw new KeyNotFoundException(message: "Category not found");
        await categoryRepo.DeleteCategory(deleteCategory.CategoryName);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
