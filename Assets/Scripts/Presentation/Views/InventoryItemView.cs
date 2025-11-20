using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InventoryItemView : MonoBehaviour
{
    public Image Icon;
    public TMP_Text ItemName;
    public TMP_Text DamageText;
    public TMP_Text MultiplierText;

    public Button EquipButton;
    public TMP_Text StateText;

    private InventoryItem _item;

    public void Setup(InventoryItem item, UnityAction<InventoryItem> onEquip)
    {
        _item = item;

        var shopItem = item.ShopItem;
        ItemName.text = shopItem.ItemName;
        Icon.sprite = shopItem.ItemSprite;

        var weaponData = (shopItem as WeaponShopItemSO)?.WeaponStats;
        DamageText.text = $"Damage: {weaponData.BaseDamage}";
        MultiplierText.text = $"Multiplier: {weaponData.RewardMultiplier}";
        
        EquipButton.onClick.RemoveAllListeners();
        EquipButton.onClick.AddListener(() => onEquip?.Invoke(_item));
    }

    public void SetEquipped(bool equipped)
    {
        StateText.text = equipped ? "Equipped" : "";
        EquipButton.interactable = !equipped;
    }
}
