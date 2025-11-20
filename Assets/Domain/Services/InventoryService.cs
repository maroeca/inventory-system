using System.Collections.Generic;


public class InventoryService : IInventoryService
{
    private readonly List<InventoryItem> _items = new();
    public void AddItem(ShopItemBaseSO item)
    {
        if (item == null)
        {
            return;
        }

        _items.Add(new InventoryItem(item));
    }

    public List<InventoryItem> GetAllItems()
    {
        return new List<InventoryItem>(_items);
    }
}
