using System.Collections;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private IShootingService _shootingService;
    private IWeaponService _weaponService;

    private bool _canShoot = true;

    public void Init(IShootingService shootingService, IWeaponService weaponService)
    {
        _shootingService = shootingService;
        _weaponService = weaponService;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        if (!_canShoot)
        {
            return;
        }
        if (!_weaponService.HasWeaponEquipped)
            return;

        StartCoroutine(ShootCooldownRoutine());
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.TryGetComponent(out ITargetProvider provider))
            {
                ITargetService target = provider.GetTargetService();
                _shootingService.Shoot(target);
                Debug.Log("Shooting");
                return;
            }
        }

        _shootingService.Shoot(null);
    }

    private IEnumerator ShootCooldownRoutine()
    {
        _canShoot = false;

        var weapon = _weaponService.GetEquippedWeapon();
        float delay = weapon.FireDelay > 0 ? weapon.FireDelay : 0.25f;
        
        yield return new WaitForSeconds(delay);
        _canShoot = true;
    }
}
