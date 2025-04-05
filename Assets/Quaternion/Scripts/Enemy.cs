using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float MinDistanceToTarget = 0.05f;
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _targets;
    private Queue<Vector3> _targetsPositions;

    private Vector3 _currentTarget;


    private void Awake()
    {
        _targetsPositions = new Queue<Vector3>();
        
       

        foreach (Transform target in _targets)
        {
                _targetsPositions.Enqueue(target.position);
        }

        SwitchTarget();

    }

    private void Update()
    {
        Vector3 direction = _currentTarget - transform.position;//Вектор направленнный от врага;
         
         if(direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();

        Vector3 normalizedDirection = direction.normalized;

        ProcessToMove(normalizedDirection);
    }

    private void ProcessToMove(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Debug.DrawLine(transform.position,direction,Color.red);
    }




    private void SwitchTarget()
    {
        _currentTarget = _targetsPositions.Dequeue();
        _targetsPositions.Enqueue(_currentTarget);

    }




}
