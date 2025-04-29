using UnityEngine;

public class Character : MonoBehaviour, IDirectionalMoveable, IDirectionRotatable
{
   private DirectionalMover _mover;
   private DirectionalRotator _rotator;

   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _rotationSpeed;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        _mover = new DirectionalMover(GetComponent<CharacterController>(),_moveSpeed);
        _rotator = new DirectionalRotator(transform, _rotationSpeed);
    }

    private void Update()
    {
       
        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);

    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

}
