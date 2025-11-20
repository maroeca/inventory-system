

public interface ICurrencyService
{
    float CurrentCoins { get; }
    void AddCoins(float amount);
    bool SpendCoins(float amount);
}
