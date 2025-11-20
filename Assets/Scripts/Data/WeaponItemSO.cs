using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItemSO", menuName = "Scriptable Objects/WeaponItemSO")]
public class WeaponItemSO : ScriptableObject
{
    public int BaseDamage;
    public float RewardMultiplier;
    public float FireDelay = 0.25f;
}
