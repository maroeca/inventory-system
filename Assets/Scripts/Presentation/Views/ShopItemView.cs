using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    public Image Icon;
    public TMP_Text NameText;
    public TMP_Text DamageText;
    public TMP_Text MultiplierText;
    public TMP_Text PriceText;

    [Header("Description")] 
    public GameObject DescriptionRoot;
    public TMP_Text DescriptionText;
    
    [Header("Selection")]
    public Button SelectButton;

    private ShopItemBaseSO _item;
    
    private RectTransform rectTransform;

    public void Setup(ShopItemBaseSO item, UnityAction<ShopItemView> onSelected)
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        _item = item;
        NameText.text = item.ItemName;
        Icon.sprite = item.ItemSprite;

        var weapon = (item as WeaponShopItemSO)?.WeaponStats;
        DamageText.text = $"Damage: {weapon.BaseDamage}";
        MultiplierText.text = $"Multiplier: {weapon.RewardMultiplier}";
        PriceText.text = $"Price: {item.ItemPrice}";
        
        DescriptionText.text = item.ItemDescription;
        DescriptionRoot.SetActive(false);
        
        SelectButton.onClick.RemoveAllListeners();
        SelectButton.onClick.AddListener(() => onSelected?.Invoke(this));

    }

    public ShopItemBaseSO GetItem() => _item;

    public void ShowDescription(bool show)
    {
        DescriptionRoot.SetActive(show);
    }

    public void SetAsOwned()
    {
        SelectButton.interactable = false;
        DescriptionRoot.SetActive(false);
        
        Icon.color = new Color(1,1,1,0.4f);
        NameText.color = new Color(1,1,1,0.4f);
        DamageText.color = new Color(1,1,1,0.4f);
        MultiplierText.color = new Color(1,1,1,0.4f);
    }

    public void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
}
