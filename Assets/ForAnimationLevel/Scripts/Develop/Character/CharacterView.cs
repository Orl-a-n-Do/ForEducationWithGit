using UnityEngine;

public class CharacterView : MonoBehaviour
{

    private readonly int isRunningKey = Animator.StringToHash("isRunning");
    private readonly int isDeathKey = Animator.StringToHash("isDeath");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;

    [SerializeField] private MainHero _mainHero;

    private void Update()
    {
        if (_mainHero != null && _mainHero.Health <= 0)
        {
            PlayDeath();
            return;
        }


        if (_character.CurrentVelocity.magnitude > 0.05f)
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
