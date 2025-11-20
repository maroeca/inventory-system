using UnityEngine;

public class ShopService : IShopService
{
    private readonly IInventoryService _inventoryService;
    private readonly ICurrencyService _currencyService;

    public ShopService(IInventoryService inventoryService, ICurrencyService currencyService)
    {
        _inventoryService = inventoryService;
        _currencyService = currencyService;
    }
    
    
    public bool TryBuy(ShopItemBaseSO item)
    {
        if (item == null)
        {
            return false;
        }

        bool canPay = _currencyService.SpendCoins(item.ItemPrice);

        if (!canPay)
        {
            return false;
        }

        _inventoryService.AddItem(item);
        return true;
    }
}
