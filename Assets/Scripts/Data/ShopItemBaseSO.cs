using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemSO", menuName = "Scriptable Objects/ShopItemSO")]
public class ShopItemBaseSO : ScriptableObject
{
    public string Id;
    public string ItemName;
    public Sprite ItemSprite;
    public string ItemDescription;
    public float ItemPrice;
}
