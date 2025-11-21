using UnityEngine;

public class WeaponHUDController: MonoBehaviour
{
    [SerializeField] private WeaponHUDView view;
    
    public WeaponHUDPresenter Presenter { get; private set; }

    public void Init(IWeaponService weaponService)
    {
        Presenter = new WeaponHUDPresenter(view, weaponService);
    }
}
