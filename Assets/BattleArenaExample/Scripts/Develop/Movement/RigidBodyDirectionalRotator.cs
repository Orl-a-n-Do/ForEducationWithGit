using UnityEngine;

public class RigidBodyDirectionalRotator : DirectionalRotator
{

    private Rigidbody _rigidbody;

    public RigidBodyDirectionalRotator(Rigidbody rigidbody , float rotationSpeed) : base(rotationSpeed)
    {
        _rigidbody = rigidbody;
    }

    public override Quaternion CurrentRotation => _rigidbody.rotation;

    protected override void ApplyRotation(Quaternion rotation) => _rigidbody.MoveRotation(rotation);
    
        
}
