using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryService : IInventoryService
{
    public List<InventoryItem> Items { get; private set; }
    public event System.Action OnInventoryChanged;

    public InventoryService()
    {
        Items = new List<InventoryItem>();
    }

    public void AddItem(ShopItemBaseSO shopItem)
    {
        if (!HasItem(shopItem))
        {
            Items.Add(new InventoryItem(shopItem));
            OnInventoryChanged?.Invoke();
        }
    }

    public bool HasItem(ShopItemBaseSO shopItem)
    {
        return Items.Any(i => i.ShopItem == shopItem);
    }

    public InventoryItem GetItem(ShopItemBaseSO shopItem)
    {
        return Items.FirstOrDefault(i => i.ShopItem == shopItem);
    }
    
    public List<InventoryItem> GetAllItems()
    {
        return new List<InventoryItem>(Items);
    }
}