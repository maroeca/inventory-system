using UnityEngine;

public class ShopService : IShopService
{
    private readonly IInventoryService _inventoryService;
    private readonly ICurrencyService _currencyService;
    private readonly IFeedbackService _feedbackService;

    public ShopService(IInventoryService inventoryService, ICurrencyService currencyService, IFeedbackService feedbackService)
    {
        _inventoryService = inventoryService;
        _currencyService = currencyService;
        _feedbackService = feedbackService;
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
            _feedbackService.ShowMessage("Not enough coins!");
            return false;
        }

        _inventoryService.AddItem(item);
        _feedbackService.ShowMessage("Item purchased!");
        return true;
    }
}
