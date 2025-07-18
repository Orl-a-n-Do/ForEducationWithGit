using UnityEngine;

public class MovableView : MonoBehaviour, IInitializable
{

    private readonly int isRunningKey = Animator.StringToHash("isRunning");
    private readonly int isDeathKey = Animator.StringToHash("isDeath");

    [SerializeField] private Animator _animator;

    [SerializeField] private MainHero _mainHero;
    private IMoveable _movable;
    private bool _isInit;


    public void Initialize()
    {
        _movable = GetComponentInParent<IMoveable>();
        _isInit = true;
    }
    
    private void Update()
    {   
        if(_isInit == false)
            return;


        if (_mainHero != null && _mainHero.Health <= 0)
        {
            PlayDeath();
            return;
        }


        if (_movable.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void StopRunning()
    {
        _animator.SetBool(isRunningKey, false);
    }

    private void StartRunning()
    {
        _animator.SetBool(isRunningKey, true);
    }
    
    private void PlayDeath()
    {
        _animator.SetBool(isDeathKey, true);
        _animator.SetBool(isRunningKey, false);
    }
}
