using UnityEngine;

public class TargetBehaviour : MonoBehaviour, ITargetProvider
{
    private ITargetService _targetService;

    public void Init(ITargetService targetService)
    {
        _targetService = targetService;
    }

    public ITargetService GetTargetService()
    {
        return _targetService;
    }
}
