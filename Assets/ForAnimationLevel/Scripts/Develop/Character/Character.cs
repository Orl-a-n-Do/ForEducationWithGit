using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDirectionalMoveable, IDirectionRotatable
{
   private DirectionalMover _mover;
   private DirectionalRotator _rotator;
    private NavMeshAgent _agent;


   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _rotationSpeed;

   
    public Vector3 CurrentVelocity
    {
        get
        {
            if (_agent != null)
                return _agent.velocity;
            return _mover != null ? _mover.CurrentVelocity : Vector3.zero;
        }
    }

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        
        if (TryGetComponent(out NavMeshAgent agent))
        {
            _agent = agent;
            // Если нужно управлять агентом вручную, можно добавить свой AgentMover и Rotator
            // _mover = new AgentMover(_agent, _moveSpeed);
            // _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        }
        if (TryGetComponent(out CharacterController characterController))
        {
            _mover = new CharacterControllerDirectionalMover(characterController, _moveSpeed);
            _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        }
        else if (TryGetComponent(out Rigidbody rigidbody))
        {
            _mover = new RigidBodyDirectionalMover(rigidbody, _moveSpeed);
            _rotator = new RigidBodyDirectionalRotator(rigidbody, _rotationSpeed);
        }
        else
        {

            Debug.Log("Не найден компонент передвижения на обьекте");
        }

    }

    private void Update()
    {
       
        _mover?.Update(Time.deltaTime);
        _rotator?.Update(Time.deltaTime);

    }

    public void SetMoveDirection(Vector3 inputDirection)
    {
        if (_agent != null)
        {
            // Для NavMeshAgent обычно используется SetDestination, а не прямое направление
            if (inputDirection != Vector3.zero)
                _agent.Move(inputDirection * _moveSpeed * Time.deltaTime);
        }
        else
        {
            _mover?.SetInputDirection(inputDirection);
        }
    }
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

}
