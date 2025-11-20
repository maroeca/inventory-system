using UnityEngine;

public class TargetService : ITargetService
{
    private readonly IRewardService _rewardService;
    private readonly ICurrencyService _currencyService;
    private readonly float _baseReward;

    public TargetService(IRewardService rewardService, ICurrencyService currencyService, float baseReward = 1f)
    {
        _rewardService = rewardService;
        _currencyService = currencyService;
        _baseReward = baseReward;
    }
    
    
    public float ApplyDamage(float damage)
    {
        if (damage <= 0)
        {
            return 0f;
        }
        
        float reward = _rewardService.CalculateReward(damage, _baseReward);
        
        _currencyService.AddCoins(reward);
        return reward;
    }
}
