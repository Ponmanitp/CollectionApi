using CollectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApi.Repository
{
    public class ItemDetailsRepo(ApplicationDBContext db)
    {
        public async Task<List<ItemDetails>> GetAllItemDetailsAsync()
        {
            return await db.ItemDetails.ToListAsync();
        }

        public async Task<ItemDetails?> GetItemDetailsByIdAsync(Guid itemId)
        {
            return await db.ItemDetails.FirstOrDefaultAsync(i => i.ItemId == itemId);
        }

        public async Task<ItemDetails> AddItemDetailsAsync(ItemDetails itemDetails)
        {
            await db.ItemDetails.AddAsync(itemDetails);
            await db.SaveChangesAsync();
            return itemDetails;
        }

        public async Task<ItemDetails> UpdateItemDetailsAsync(ItemDetails itemDetails)
        {
            db.ItemDetails.Update(itemDetails);
            await db.SaveChangesAsync();
            return itemDetails;
        }
        public async Task<bool> DeleteItemDetailsAsync(Guid itemId)
        {
            var itemDetails = await GetItemDetailsByIdAsync(itemId)
                ?? throw new KeyNotFoundException("Item not found");
            db.ItemDetails.Remove(itemDetails);
            await db.SaveChangesAsync();
            return true;
        }

    }
}
