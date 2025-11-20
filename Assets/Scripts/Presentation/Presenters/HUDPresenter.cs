using UnityEngine;

public class HUDPresenter
{
    private readonly ICurrencyService _currencyService;
    private readonly HUDView _view;

    public HUDPresenter(ICurrencyService currencyService, HUDView view)
    {
        _currencyService = currencyService;
        _view = view;
        
        _view.SetCoins(_currencyService.CurrentCoins);

        _currencyService.OnCoinsChanged += HandleCoinsChanged;
    }

    private void HandleCoinsChanged(float newAmount)
    {
        _view.SetCoins(newAmount);
    }
}
