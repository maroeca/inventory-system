using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private IShootingService _shootingService;
    private IWeaponService _weaponService;
    private IGameStateService _gameStateService;

    private bool _canShootDelay = true;

    public void Init(IShootingService shootingService, IWeaponService weaponService, IGameStateService gameStateService)
    {
        _shootingService = shootingService;
        _weaponService = weaponService;
        _gameStateService = gameStateService;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && CanShoot())
        {
            TryShoot();
        }
    }
    
    private bool CanShoot()
    {
        if (_gameStateService.CurrentState != GameState.ShootingRange)
            return false;

        if (IsPointerOverUI())
            return false;

        return true;
    }
    
    private bool IsPointerOverUI()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);

        foreach (var r in results)
        {
            // Se achou um Button, Slider, Toggle etc → é UI interativa
            if (r.gameObject.GetComponent<Button>() != null ||
                r.gameObject.GetComponent<Toggle>() != null ||
                r.gameObject.GetComponent<Slider>() != null ||
                r.gameObject.GetComponent<InputField>() != null)
            {
                return true;
            }
        }

        return false;
    }


    private void TryShoot()
    {
        if (!_canShootDelay)
        {
            return;
        }

        StartCoroutine(ShootCooldownRoutine());
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.TryGetComponent(out ITargetProvider provider))
            {
                ITargetService target = provider.GetTargetService();
                _shootingService.Shoot(target);
                return;
            }
        }

        _shootingService.Shoot(null);
    }

    private IEnumerator ShootCooldownRoutine()
    {
        _canShootDelay = false;

        var weapon = _weaponService.GetEquippedWeapon();
        float delay = weapon?.FireDelay > 0 ? weapon.FireDelay : 0.25f;
        
        yield return new WaitForSeconds(delay);
        _canShootDelay = true;
    }
}
