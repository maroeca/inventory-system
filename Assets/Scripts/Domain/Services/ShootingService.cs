using System;
using UnityEngine;

public class ShootingService :IShootingService
{
    private readonly IWeaponService _weaponService;
    private readonly IFeedbackService _feedbackService;

    public ShootingService(IWeaponService weaponService, IFeedbackService feedbackService)
    {
        _weaponService = weaponService;
        _feedbackService = feedbackService;
    }
    
    public bool Shoot(ITargetService target)
    {
        if (!_weaponService.HasWeaponEquipped)
        {
            _feedbackService.ShowMessage("Equip a weapon first!");
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
        target.ApplyDamage(weaponStats.BaseDamage, weaponStats.RewardMultiplier);
        return true;   
    }
}
