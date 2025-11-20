using System.Collections.Generic;
using UnityEngine;

public class ShopPresenter
{
    private readonly ShopView _view;
    private readonly IShopService _shopService;
    private readonly IInventoryService _inventoryService;

    private readonly List<ShopItemView> _itemViews = new();

    private ShopItemView _selectedItem;

    private readonly List<ShopItemBaseSO> _items;

    public ShopPresenter(
        ShopView view,
        IShopService shopService,
        IInventoryService inventoryService,
        List<ShopItemBaseSO> items)
    {
        _view = view;
        _shopService = shopService;
        _inventoryService = inventoryService;
        _items = items;

        _view.buyButton.interactable = false;
        _view.buyButton.onClick.AddListener(OnBuyClicked);

        BuildList();
    }

    private void BuildList()
    {
        foreach (Transform t in _view.itemsParent)
            GameObject.Destroy(t.gameObject);

        _itemViews.Clear();

        foreach (var item in _items)
        {
            var go = GameObject.Instantiate(_view.itemPrefab, _view.itemsParent);
            var view = go.GetComponent<ShopItemView>();

            view.Setup(item, OnItemSelected);
            view.RebuildLayout();

            if (_inventoryService.HasItem(item))
                view.SetAsOwned();

            _itemViews.Add(view);
        }
    }

    private void OnItemSelected(ShopItemView selected)
    {
        if (!_inventoryService.HasItem(selected.GetItem()))
        {
            _selectedItem = selected;

            foreach (var view in _itemViews)
                view.ShowDescription(false);

            selected.ShowDescription(true);

            _view.buyButton.interactable = true;
        }
    }

    private void OnBuyClicked()
    {
        if (_selectedItem == null)
            return;

        var item = _selectedItem.GetItem();

        if (_shopService.TryBuy(item))
        {
            BuildList(); 
            _view.buyButton.interactable = false;
        }
    }
    
    public void RebuildLayout()
    {
        foreach (var view in _itemViews)
            view.RebuildLayout();
    }

}
