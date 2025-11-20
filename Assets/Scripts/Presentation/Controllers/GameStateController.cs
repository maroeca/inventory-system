using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    private IGameStateService _stateService;

    [Header("Go To Shop")]
    [SerializeField] private List<Button> goToShopButtons = new List<Button>();

    [Header("Go To Inventory")]
    [SerializeField] private List<Button> goToInventoryButtons = new List<Button>();

    [Header("Go To Shooting")]
    [SerializeField] private List<Button> goToShootingButtons = new List<Button>();

    [Header("Go To Menu")]
    [SerializeField] private List<Button> goToMenuButtons = new List<Button>();

    public void Init(IGameStateService stateService)
    {
        _stateService = stateService;

        foreach (var btn in goToShopButtons)
            if (btn != null)
                btn.onClick.AddListener(() => _stateService.SetState(GameState.Shop));

        foreach (var btn in goToInventoryButtons)
            if (btn != null)
                btn.onClick.AddListener(() => _stateService.SetState(GameState.Inventory));

        foreach (var btn in goToShootingButtons)
            if (btn != null)
                btn.onClick.AddListener(() => _stateService.SetState(GameState.ShootingRange));

        foreach (var btn in goToMenuButtons)
            if (btn != null)
                btn.onClick.AddListener(() => _stateService.SetState(GameState.Menu));
    }
}