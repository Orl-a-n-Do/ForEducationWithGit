using UnityEngine;

public class AgentCharacterView : MonoBehaviour, IInitializable
{
    private readonly int isRunningKey = Animator.StringToHash("isRunning");

    private const string EdgeKey = "_Edge";

    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;

    [SerializeField] private SkinnedMeshRenderer[] _renderers;

    public void Initialize()
    {
        _renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        UpdateRenderers();
    }


    private void Update()
    {

        UpdateRenderers();


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

    private void UpdateRenderers()
    {
        if (_character.InSpawnProcess(out float elapsedTime))
            SetFloatFor(_renderers, EdgeKey, 1 - elapsedTime / _character.TimeToSwpawn);
        else
            SetFloatFor(_renderers, EdgeKey, 0);    

    }

    

    private void SetFloatFor(SkinnedMeshRenderer[] renderers, string key, float param)
    {
        foreach (SkinnedMeshRenderer renderer in renderers)
            renderer.material.SetFloat(key, param);

    }

}
