using System.Collections.Generic;
using UnityEngine;

public class InventoryPresenter
{
    private readonly InventoryView _view;
    private readonly IInventoryService _inventoryService;
    private readonly IWeaponService _weaponService;

    private List<InventoryItemView> _itemViews = new();

    public InventoryPresenter(InventoryView view, IInventoryService inventoryService, IWeaponService weaponService)
    {
        _view = view;
        _inventoryService = inventoryService;
        _weaponService = weaponService;

        _inventoryService.OnInventoryChanged += BuildList;

        BuildList();
    }

    public void Dispose()
    {
        _inventoryService.OnInventoryChanged -= BuildList;
    }

    private void BuildList()
    {
        foreach (Transform t in _view.itemsParent)
        {
            GameObject.Destroy(t.gameObject);
        }
        
        _itemViews.Clear();

        var equipped = _weaponService.GetEquippedShopItem();
        foreach (var item in _inventoryService.GetAllItems())
        {
            var go = GameObject.Instantiate(_view.itemPrefab, _view.itemsParent);
            var itemView = go.GetComponent<InventoryItemView>();
            
            itemView.Setup(item, OnEquipItem);

            bool isEquipped = item.ShopItem == equipped;
            itemView.SetEquipped(isEquipped);
            
            _itemViews.Add(itemView);
        }
    }

    private void OnEquipItem(InventoryItem item)
    {
        _weaponService.Equip(item);
        BuildList();
    }
}
