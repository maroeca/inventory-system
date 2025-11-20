using System;

public class GameStatePresenter
{
    private readonly IGameStateService _service;
    private readonly GameStateView _view;
    public event Action OnShopOpened;

    public GameStatePresenter(IGameStateService service, GameStateView view)
    {
        _service = service;
        _view = view;
        
        _service.OnStateChanged += HandleStateChanged;

        _view.ShowState(_service.CurrentState);
    }

    private void HandleStateChanged(GameState state)
    {
        _view.ShowState(state);

        if (state == GameState.Shop)
        {
            OnShopOpened?.Invoke();
        }
    }
}