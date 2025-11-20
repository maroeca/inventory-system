
[System.Serializable]
public class InventoryItem
{
    public ShopItemBaseSO ShopItem;

    public InventoryItem(ShopItemBaseSO item)
    {
        ShopItem = item;
    }
}
