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
        if(TryGetComponent(out CharacterController characterController))
        {
            _mover = new CharacterControllerDirectionalMover(characterController,_moveSpeed);
            _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        }
        else if(TryGetComponent(out Rigidbody rigidbody))
        {
            _mover = new RigidBodyDirectionalMover(rigidbody,_moveSpeed);
            _rotator = new RigidBodyDirectionalRotator(rigidbody, _rotationSpeed);
        }
        else    
        {

            Debug.Log("Не найден компонент передвижения на обьекте");
        }

    }

    private void Update()
    {
       
        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);

    }

    public void SetMoveDirection(Vector3 inputDirection) => _mover.SetInputDirection(inputDirection);
    public void SetRotationDirection(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

}
