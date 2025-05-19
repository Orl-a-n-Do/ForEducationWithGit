using UnityEngine;

public class PlayerView : MonoBehaviour
{
   
    private readonly int isRunningKey = Animator.StringToHash("isRunning");
    private readonly int isDeathKey = Animator.StringToHash("isDeath");
    private readonly int isInjuredKey = Animator.StringToHash("isInjured");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;
    [SerializeField] private MainHero _mainHero;

    private bool _isDead = false;

    private void Update()
    {
        if (_isDead)
            return;

        if (_mainHero != null && _mainHero.Health <= 0)
        {
            PlayDeath();
            return;
        }


        if (_mainHero != null)

        {
            int injuredLayerIndex = _animator.GetLayerIndex("InjuredLayer");
            if (injuredLayerIndex >= 0)
            {
                float targetWeight = _mainHero.Health < 40 ? 1f : 0f;
                _animator.SetLayerWeight(injuredLayerIndex, targetWeight);
            }
            
        }


        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void StopRunning()
    {
        if (_isDead) return;
        _animator.SetBool(isRunningKey, false);
    }

    private void StartRunning()
    {
        if (_isDead) return;
        _animator.SetBool(isRunningKey, true);
    }

   
    private void PlayDeath()
    {
        _isDead = true;
        _animator.SetBool(isDeathKey, true);
        _animator.SetBool(isRunningKey, false);

        // Отключаем NavMeshAgent, чтобы нельзя было двигать героя
        var agent = _character.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
            agent.enabled = false;
    }
}
