using UnityEngine;

public class GameStateView : MonoBehaviour
{
    [Header("Panels")]
    public GameObject menuPanel;
    public GameObject shopPanel;
    public GameObject inventoryPanel;
    public GameObject shootingPanel;

    public void ShowState(GameState state)
    {
        menuPanel.SetActive(state == GameState.Menu);
        shopPanel.SetActive(state == GameState.Shop);
        inventoryPanel.SetActive(state == GameState.Inventory);
        shootingPanel.SetActive(state == GameState.ShootingRange);
    }
}