using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IMoveable, ICanSpawn
{
    private NavMeshAgent _agent;


    private AgentMover _mover;
    private TransformDirectionalRotator _rotator;

    private AgentJumper _jumper;

    private Timer _spawnTimer;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _jumpSpeed;
    [SerializeField] private AnimationCurve _jumpCurve;

    [SerializeField] private float _timeToSwpawn;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public bool InJumpProcess => _jumper.InProcess;

    public float TimeToSwpawn => _spawnTimer.TimeLimit;


    public void Initialize()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        _jumper = new AgentJumper(_jumpSpeed, _agent, this, _jumpCurve);

        _spawnTimer = new Timer(this);

        _spawnTimer.StartProcess(_timeToSwpawn);

        foreach(IInitializable initializable in GetComponentsInChildren<IInitializable>())
            initializable.Initialize();

    }

    private void Update()
    {
        _rotator.SetInputDirection(_agent.desiredVelocity);
        _rotator.Update(Time.deltaTime);
    }

    public void SetDestination(Vector3 position) => _mover.SetDestination(position);
    public void StopMove() => _mover.Stop();
    public void ResumeMove() => _mover.Resume();
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
        => NavMeshUtils.TryGetPass(_agent, targetPosition, pathToTarget);



    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if (_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }

    public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);

    // Реализация интерфейса IDirectionalMoveable
    public void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Vector3 targetPosition = transform.position + direction;
            SetDestination(targetPosition);
        }
        else
        {
            StopMove();
        }
    }

    public bool InSpawnProcess(out float elapsedTime) => _spawnTimer.InProcess(out elapsedTime);



}
