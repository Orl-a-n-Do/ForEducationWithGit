using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDirectionRotatable: ITransformPosition
{
    void SetRotationDirection(Vector3 inputDirection);
    Quaternion CurrentRotation{get; }
}
