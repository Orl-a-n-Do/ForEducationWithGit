using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDirectionalMoveable, IDirectionRotatable
{
   private DirectionalMover _mover;
   private DirectionalRotator _rotator;
    private NavMeshAgent _agent;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _cameraTarget;

   
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
    
    public Transform CameraTarget => _cameraTarget;

    public void Initialize(DirectionalMover mover, DirectionalRotator rotator)
    {
        _mover = mover;
        _rotator = rotator;

        foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
            initializable.Initialize();
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
