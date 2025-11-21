using UnityEngine;

public class WeaponHUDPresenter
{
    private readonly WeaponHUDView _view;
    private readonly IWeaponService _weaponService;

    public WeaponHUDPresenter(WeaponHUDView view, IWeaponService weaponService)
    {
        _view = view;
        _weaponService = weaponService;

        _weaponService.OnWeaponChanged += UpdateHUD;
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        var weaponSO = _weaponService.GetEquippedWeapon();
        var inventoryItem = _weaponService.GetEquippedInventoryItem();

        if (weaponSO == null || inventoryItem == null)
        {
            _view.Hide();
            return;
        }
        
        _view.ShowWeapon(weaponSO, inventoryItem.ShopItem.ItemSprite, inventoryItem.ShopItem.ItemName);
    }
}
