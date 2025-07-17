using UnityEngine;

public interface IDirectionalMoveable : ITransformPosition, IMoveable
{

    void SetMoveDirection(Vector3 inputDirection);
    
    
}
