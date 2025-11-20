
using System.Collections.Generic;

public interface IInventoryService
{
    void AddItem(ShopItemBaseSO item);
    List<InventoryItem> GetAllItems();
}
