using CollectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApi.Repository;

public class CollectionsRepo(ApplicationDBContext db)
{
    public async Task<List<Collections>> GetAllItemDetailsAsync()
    {
        return await db.Collections.ToListAsync();
    }

    public async Task<Collections?> GetItemDetailsByIdAsync(Guid itemId)
    {
        return await db.Collections.FirstOrDefaultAsync(i => i.ItemId == itemId);
    }

    public async Task<Collections> AddItemDetailsAsync(Collections collections)
    {
        await db.Collections.AddAsync(collections);
        await db.SaveChangesAsync();
        return collections;
    }

    public async Task<Collections> UpdateItemDetailsAsync(Collections collections)
    {
        db.Collections.Update(collections);
        await db.SaveChangesAsync();
        return collections;
    }
    public async Task DeleteItemDetailsAsync(Guid itemId)
    {
        var itemDetails = await GetItemDetailsByIdAsync(itemId)
            ?? throw new KeyNotFoundException("Item not found");
        db.Collections.Remove(itemDetails);
        await db.SaveChangesAsync();
    }

}
