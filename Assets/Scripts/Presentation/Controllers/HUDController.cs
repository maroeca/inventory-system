using UnityEngine;

public class HUDController : MonoBehaviour
{
   [SerializeField] private HUDView hudView;
   
   private HUDPresenter _presenter;

   public void Init(ICurrencyService currencyService)
   {
      _presenter = new HUDPresenter(currencyService, hudView);
   }
}
