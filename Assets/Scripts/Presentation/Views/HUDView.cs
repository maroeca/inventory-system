using TMPro;
using UnityEngine;

public class HUDView : MonoBehaviour
{
    [SerializeField] TMP_Text coinsText;

    public void SetCoins(float amount)
    {
        coinsText.text = "Coins: " + amount.ToString("0");
    }
}
