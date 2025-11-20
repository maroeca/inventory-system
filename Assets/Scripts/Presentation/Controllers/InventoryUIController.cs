using System;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private InventoryView inventoryView;
    
    public InventoryPresenter Presenter { get; private set; }

    public void Init(IInventoryService inventoryService, IWeaponService weaponService)
    {
        Presenter = new InventoryPresenter(inventoryView, inventoryService, weaponService);
    }

    private void OnDestroy()
    {
        Presenter.Dispose();
    }
}
