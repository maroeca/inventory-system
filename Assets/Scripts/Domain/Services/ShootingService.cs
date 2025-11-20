using System;
using UnityEngine;

public class ShootingService :IShootingService
{
    private readonly IWeaponService _weaponService;

    public ShootingService(IWeaponService weaponService)
    {
        _weaponService = weaponService;
    }
    
    public bool Shoot(ITargetService target)
    {
        if (!_weaponService.HasWeaponEquipped)
        {
            return false;
        }

        if (target == null)
        {
            return true;
        }

        var weaponStats = _weaponService.GetEquippedWeapon();

        if (weaponStats == null)
        {
            return false;
        }
        target.ApplyDamage(weaponStats.BaseDamage);
        return true;   
    }
}
