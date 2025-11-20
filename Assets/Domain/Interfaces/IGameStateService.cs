using System;
public enum GameState
{
    Menu,
    Shop,
    Inventory,
    ShootingRange,
    Feedback
}

public interface IGameStateService
{
    GameState CurrentState { get; }
    void SetState(GameState newState);
    event Action<GameState> OnStateChanged;
}
