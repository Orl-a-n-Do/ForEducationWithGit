using UnityEngine;

public class RigidBodyDirectionalMover : DirectionalMover
{
   
    private Rigidbody _rigidbody;


    public RigidBodyDirectionalMover(Rigidbody rigidbody, float movementSpeed): base(movementSpeed)
    {
        _rigidbody = rigidbody;
        
    }

    public override void Update(float deltaTime) => _rigidbody.velocity = CurrentVelocity;
    
}