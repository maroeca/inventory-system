
using System;

public class GameStateService : IGameStateService
{
    private GameState _currentState;
    public GameState CurrentState => _currentState;
    
    public event Action<GameState> OnStateChanged;

    public GameStateService(GameState initialState = GameState.Menu)
    {
        _currentState = initialState;
    }
    
    public void SetState(GameState newState)
    {
        if (newState == _currentState)
        {
            return;
        }
        
        _currentState = newState;
        OnStateChanged?.Invoke(newState);
    }

}
