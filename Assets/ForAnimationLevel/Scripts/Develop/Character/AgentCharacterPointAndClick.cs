using UnityEngine;
using UnityEngine.AI;

public class AgentCharacterPointAndClick : Controller
{
    private NavMeshAgent _agent;
    private Transform _target;

    private float _agroRange;
    private float _minDistanceToTarget;


    private float _idleTimer;
    private float _timeForIdle;


    private NavMeshPath _pathToTarget = new NavMeshPath();

    public AgentCharacterPointAndClick(
        Transform target,
         float agroRange,
         float minDistanceToTarget,
         float timeForIdle)
    {
         _target = target;
         _agroRange = agroRange;
         _minDistanceToTarget = minDistanceToTarget;
         _timeForIdle = timeForIdle;
         _idleTimer = 0f;
         _pathToTarget = new NavMeshPath();
    }


    public bool TryGetPass(Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPass(_agent, targetPosition, pathToTarget);


    protected override void UpdateLogic(float deltaTime)
    {

        


    }
}