using UnityEngine;

public class CharacterView : MonoBehaviour
{

    private readonly int isRunningKey = Animator.StringToHash("isRunning");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;


    private void Update()
    {
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
}
