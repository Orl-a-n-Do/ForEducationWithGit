using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private readonly int isRunningKey = Animator.StringToHash("isRunning");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;


    private void Update()
    {
        if (_character.CurrentVelocity.magnitude > 0.05)
            StarRunning();

        else
            StopRunning();
    }

    private void StopRunning()
    {
        _animator.SetBool(isRunningKey, false);
    }

    private void StarRunning()
    {
        _animator.SetBool(isRunningKey, true);
    }
}
