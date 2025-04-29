using UnityEngine;

public interface IDirectionalMoveable: ITransformPosition
{
    Vector3 CurrentVelocity{get;}
    void SetMoveDirection(Vector3 inputDirection);
}
