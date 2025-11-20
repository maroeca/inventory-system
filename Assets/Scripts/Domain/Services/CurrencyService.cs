using System;

namespace Domain.Services
{
    public class CurrencyService :ICurrencyService
    {
        private float _coins;
        public float CurrentCoins => _coins;

        public event Action<float> OnCoinsChanged;
        public CurrencyService(float startingCoins = 0)
        {
            _coins = startingCoins;
        }
        public void AddCoins(float amount)
        {
            if (amount <= 0)
            {
                return;
            }

            _coins += amount;
            OnCoinsChanged?.Invoke(_coins);
        }

        public bool SpendCoins(float amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (_coins < amount)
            {
                return false;
            }

            _coins -= amount;
            OnCoinsChanged?.Invoke(_coins);
            return true;
        }

    }
}