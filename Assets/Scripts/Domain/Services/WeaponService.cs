using UnityEngine;

public class WeaponService :IWeaponService
{
    private InventoryItem _equippedItem;
    public bool HasWeaponEquipped => _equippedItem != null;
    public event System.Action OnWeaponChanged;
    
    public void Equip(InventoryItem item)
    {
        if (item == null)
        {
            _equippedItem = null;
            return;
        }

        if (item.ShopItem is WeaponShopItemSO && item != _equippedItem)
        {
            _equippedItem = item;
            OnWeaponChanged?.Invoke();
        }
        else
        {
            _equippedItem = null;
        }
    }

    public void Unequip()
    {
        _equippedItem = null;
        OnWeaponChanged?.Invoke();
    }

    public WeaponItemSO GetEquippedWeapon()
    {
        if (_equippedItem == null)
        {
            return null;
        }

        if (_equippedItem.ShopItem is WeaponShopItemSO weaponShopItem)
        {
            return weaponShopItem.WeaponStats;
        }
        
        return null; 
    }
    
    public InventoryItem GetEquippedInventoryItem()
    {
        return _equippedItem;
    }

    public ShopItemBaseSO GetEquippedShopItem()
    {
        return _equippedItem?.ShopItem;
    }
}
