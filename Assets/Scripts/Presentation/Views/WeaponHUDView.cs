using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class WeaponHUDView : MonoBehaviour
{
    public Image Icon;
    public TMP_Text NameText;
    public TMP_Text DamageText;
    public TMP_Text MultiplierText;
    public TMP_Text FireDelayText;

    public void ShowWeapon(WeaponItemSO weaponData, Sprite iconSprite, string weaponName)
    {
        gameObject.SetActive(true);
        
        Icon.sprite = iconSprite;
        NameText.text = weaponName;
        DamageText.text = $"Damage: {weaponData.BaseDamage}";
        MultiplierText.text = $"Multiplier: {weaponData.RewardMultiplier}";
        FireDelayText.text = $"Fire Delay: {weaponData.FireDelay}s";
    }

    public void Hide()
    {
        gameObject.SetActive(false); 
    }
}
