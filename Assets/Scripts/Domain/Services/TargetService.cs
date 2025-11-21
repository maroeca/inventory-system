using UnityEngine;

public class TargetService : ITargetService
{
    private readonly IRewardService _rewardService;
    private readonly ICurrencyService _currencyService;

    public TargetService(IRewardService rewardService, ICurrencyService currencyService)
    {
        _rewardService = rewardService;
        _currencyService = currencyService;
    }
    
    
    public float ApplyDamage(float damage, float multiplier)
    {
        if (damage <= 0)
        {
            return 0f;
        }
        
        float reward = _rewardService.CalculateReward(damage,multiplier);
        
        _currencyService.AddCoins(reward);
        return reward;
    }
}
