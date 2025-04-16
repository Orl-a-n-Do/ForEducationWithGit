using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private float MinDistanceToTarget = 0.05f;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;


    private List<Transform> _targets;

    private Transform _currentTarget;

    private ITargetSelector _targetSelector;

    public void Initialize(ITargetSelector targetSelector, List<Transform> targets)
    {
        SetTargetSelector(targetSelector);
        _targets = targets;
    }
    
    public void SetTargetSelector(ITargetSelector targetSelector)
    {
        _targetSelector = targetSelector;
        UpdateTarget();
       
    }



    private void Awake()
    {
        UpdateTarget();
    }


    private void Update()
    {
        Vector3 direction = GetDirectionTo(_currentTarget);

        if(direction.magnitude <= MinDistanceToTarget)
        {
            UpdateTarget();
            return;
        }

        Vector3 normalizedDirection = direction.normalized;

        ProcessMoveTo(normalizedDirection);
        ProcessRotateTo(normalizedDirection);
        
    }


    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction, Color.blue);
    }


    private Vector3 GetDirectionTo(Transform target) => target.position - transform.position;


    private void ProcessRotateTo(Vector3 direction)
    {
        Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(xzDirection);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,step );
    }


    private void UpdateTarget() => _currentTarget = _targetSelector.SelectFrom(_targets);   
   
}
