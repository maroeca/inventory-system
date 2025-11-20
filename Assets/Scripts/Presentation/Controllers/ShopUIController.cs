using UnityEngine;
using System.Collections.Generic;
public class ShopUIController : MonoBehaviour
{
    [SerializeField] private ShopView shopView;
    [SerializeField] private List<ShopItemBaseSO> shopItems;

    public ShopPresenter Presenter { get; private set; }


    public void Init(
        IShopService shopService,
        IInventoryService inventoryService)
    {
        Presenter = new ShopPresenter(shopView, shopService, inventoryService, shopItems);
    }
}