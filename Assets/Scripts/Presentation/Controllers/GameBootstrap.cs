using System;
using System.Net.Mime;
using Domain.Services;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [Header("Controllers")] 
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private TargetBehaviour targetBehaviour;
    [SerializeField] private GameStateView gameStateView;
    [SerializeField] private WeaponShopItemSO startingWeapon;
    
    
    [Header("UI")]
    [SerializeField] private HUDController hudController;
    [SerializeField] private ShopUIController shopUIController;
    [SerializeField] private InventoryUIController inventoryUIController;
    [SerializeField] private GameStateController gameStateController;
    
    private IInventoryService _inventoryService;
    private ICurrencyService _currencyService;
    private IShopService _shopService;
    private IWeaponService _weaponService;
    private IRewardService _rewardService;
    private ITargetService _targetService;
    private IShootingService _shootingService;
    private IGameStateService _gameStateService;
    
    private GameStatePresenter _gameStatePresenter;
    private ShopPresenter _shopPresenter;

    private void Awake()
    {
        InitializeServices();
        InjectDependencies();
    }

    private void InitializeServices()
    {
        _inventoryService = new InventoryService();
        _currencyService = new CurrencyService(startingCoins: 50);
        _weaponService = new WeaponService();
        _rewardService = new RewardService();
        _targetService = new TargetService(_rewardService, _currencyService);
        _shootingService = new ShootingService(_weaponService);
        _shopService = new ShopService(_inventoryService, _currencyService);
        _gameStateService = new GameStateService(GameState.Menu);
    }

    private void InjectDependencies()
    {
        shootingController.Init(_shootingService, _weaponService);
        targetBehaviour.Init(_targetService);
        gameStateController.Init(_gameStateService);
        _gameStatePresenter = new GameStatePresenter(_gameStateService, gameStateView);
        
        hudController.Init(_currencyService);
        shopUIController.Init(_shopService, _inventoryService);
        _gameStatePresenter.OnShopOpened += shopUIController.Presenter.RebuildLayout;
        inventoryUIController.Init(_inventoryService, _weaponService);

        /*hudController.Init(_currencyService);
        shopUIController.Init(_shopService, _inventoryService, _weaponService);
        inventoryUIController.Init(_inventoryService, _weaponService);
        gameStateController.Init(_gameStateService);*/
    }
}
