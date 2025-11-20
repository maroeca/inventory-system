using UnityEngine;

public class RewardService :IRewardService
{
    public float CalculateReward(float damage, float multiplier)
    {
        if (damage <= 0)
        {
            return 0f;
        }

        if (multiplier <= 0)
        {
            multiplier = 1f;
        }
        
        return damage * multiplier;
    }
}
