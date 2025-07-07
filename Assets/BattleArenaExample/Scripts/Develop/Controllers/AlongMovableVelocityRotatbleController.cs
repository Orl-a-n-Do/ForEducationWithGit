using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlongMovableVelocityRotatableController : Controller
{
    private IDirectionRotatable _rotatable;
    private IDirectionalMoveable _movable;

    public AlongMovableVelocityRotatableController(IDirectionRotatable rotatable,IDirectionalMoveable moveable)
    {
        _rotatable = rotatable;
        _movable = moveable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _rotatable.SetRotationDirection(_movable.CurrentVelocity);
    }

    
}
