

public interface IWeaponService
{
    void Equip(InventoryItem item);
    void Unequip();
    WeaponItemSO GetEquippedWeapon();
    
    bool HasWeaponEquipped { get; }
}
