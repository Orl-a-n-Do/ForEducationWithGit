using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAIDirectionalMovableController : Controller
{
    private IDirectionalMoveable _movable;

    private float _time;
    private float _timeToChangeDirection;

    private Vector3 _inputDirection;

    public RandomAIDirectionalMovableController(IDirectionalMoveable moveable, float timeToChangeDirection)
    {
        _movable = moveable;
        _timeToChangeDirection = timeToChangeDirection;

    }

    protected override void UpdateLogic(float deltaTime)
    {
        _time += Time.deltaTime;

        if(_time >= _timeToChangeDirection)
        {
            _inputDirection = new Vector3(Random.Range(-1f,1f), 0 ,Random.Range(-1f,1f));
            _time = 0;
        }
       _movable.SetMoveDirection(_inputDirection);
    }
}
