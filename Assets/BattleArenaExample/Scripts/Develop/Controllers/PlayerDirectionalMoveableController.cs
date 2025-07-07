using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionalMoveableController : Controller
{
    private IDirectionalMoveable _movable;

    public PlayerDirectionalMoveableController(IDirectionalMoveable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));

        _movable.SetMoveDirection(inputDirection);

    }
}
