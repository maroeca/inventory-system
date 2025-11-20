
using System.Collections.Generic;

public interface IInventoryService
{
    void AddItem(ShopItemBaseSO item);
    bool HasItem(ShopItemBaseSO item);
    InventoryItem GetItem(ShopItemBaseSO shopItem);
    List<InventoryItem> GetAllItems();
    event System.Action OnInventoryChanged; 
}
