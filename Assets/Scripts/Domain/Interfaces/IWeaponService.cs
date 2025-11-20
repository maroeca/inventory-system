

public interface IWeaponService
{
    void Equip(InventoryItem item);
    void Unequip();
    WeaponItemSO GetEquippedWeapon();
    ShopItemBaseSO GetEquippedShopItem();
    InventoryItem GetEquippedInventoryItem();
    
    bool HasWeaponEquipped { get; }
}
