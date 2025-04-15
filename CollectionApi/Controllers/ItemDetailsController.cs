using CollectionApi.Models;
using CollectionApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollectionApi.Controllers;

[Route(PathController)]
public class ItemDetailsController(ItemDetailsRepo itemDetailsRepo) : RootController
{
    [HttpGet("{itemId}", Name = nameof(GetItemDetailsByIdAsync))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ItemDetails> GetItemDetailsByIdAsync(Guid itemId)
    {
        var ItemDetails = await itemDetailsRepo.GetItemDetailsByIdAsync(itemId)
                ?? throw new KeyNotFoundException("Item not found");
        return ItemDetails;
    }

    [HttpGet(Name = nameof(GetAllItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<ItemDetails>> GetAllItemDetailsAsync()
    {
        var ItemDetails = await itemDetailsRepo.GetAllItemDetailsAsync();
        return ItemDetails;
    }

    [HttpPost(Name = nameof(AddItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ItemDetails> AddItemDetailsAsync(ItemDetails itemDetails)
    {

        var addItem = await itemDetailsRepo.AddItemDetailsAsync(itemDetails)
                ?? throw new KeyNotFoundException("Item not found");
        return addItem;
    }

    [HttpPut(Name = nameof(UpdateItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ItemDetails> UpdateItemDetailsAsync(ItemDetails itemDetails)
    {
        var getExistingItem = await itemDetailsRepo.GetItemDetailsByIdAsync(itemDetails.ItemId)
            ?? throw new KeyNotFoundException("Item not found");
        var updateItem = await itemDetailsRepo.UpdateItemDetailsAsync(getExistingItem);
        return updateItem;
    }

    [HttpDelete("{itemId}", Name = nameof(DeleteItemDetailsAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeleteItemDetailsAsync(Guid itemId)
    {
        var getExistingItem = await itemDetailsRepo.GetItemDetailsByIdAsync(itemId)
            ?? throw new KeyNotFoundException("Item not found");
        await itemDetailsRepo.DeleteItemDetailsAsync(getExistingItem.ItemId);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }
}
