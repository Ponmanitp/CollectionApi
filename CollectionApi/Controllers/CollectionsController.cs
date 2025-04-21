using CollectionApi.Models;
using CollectionApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApi.Controllers;

[Route(PathController)]
public class CollectionsController(CollectionsRepo collectionsRepo) : RootController
{
    [HttpGet("{itemId}", Name = nameof(GetItemDetailsByIdAsync))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Collections> GetItemDetailsByIdAsync(Guid itemId)
    {
        var ItemDetails = await collectionsRepo.GetItemDetailsByIdAsync(itemId)
                ?? throw new KeyNotFoundException("Item not found");
        return ItemDetails;
    }

    [HttpGet(Name = nameof(GetAllItemDetailsAsync))]
    public async Task<List<Collections>> GetAllItemDetailsAsync()
    {
        var ItemDetails = await collectionsRepo.GetAllItemDetailsAsync();
        return ItemDetails;
    }

    [HttpPost(Name = nameof(AddItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Collections> AddItemDetailsAsync(Collections itemDetails)
    {
        var addItem = await collectionsRepo.AddItemDetailsAsync(itemDetails)
                ?? throw new KeyNotFoundException("Item not found");
        return addItem;
    }

    [HttpPut(Name = nameof(UpdateItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Collections> UpdateItemDetailsAsync(Collections itemDetails)
    {
        var getExistingItem = await collectionsRepo.GetItemDetailsByIdAsync(itemDetails.ItemId)
            ?? throw new KeyNotFoundException("Item not found");
        var updateItem = await collectionsRepo.UpdateItemDetailsAsync(getExistingItem);
        return updateItem;
    }

    [HttpDelete("{itemId}", Name = nameof(DeleteItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeleteItemDetailsAsync(Guid itemId)
    {
        var getExistingItem = await collectionsRepo.GetItemDetailsByIdAsync(itemId)
            ?? throw new KeyNotFoundException("Item not found");
        await collectionsRepo.DeleteItemDetailsAsync(getExistingItem.ItemId);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
