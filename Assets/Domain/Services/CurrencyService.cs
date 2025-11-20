namespace Domain.Services
{
    public class CurrencyService :ICurrencyService
    {
        private float _coins;
        public float CurrentCoins => _coins;

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
            return true;
        }
    }
}