using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopDatabaseSO", menuName = "Scriptable Objects/ShopDatabaseSO")]
public class ShopDatabaseSO : ScriptableObject
{
    public List<ShopItemBaseSO> ShopItems;
}
