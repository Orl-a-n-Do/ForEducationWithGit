using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTargetSellector : ITargetSelector
{
    private Transform _source;

    public DistanceTargetSellector(Transform source)
    {
        _source = source;
    }

    public Transform SelectFrom(List<Transform> targets)
    {
        Transform selectedTarget = targets[0];

        foreach(Transform target in targets)
        {
            Vector3 direction = GetDirectionTo(target);

            if(direction.magnitude > GetDirectionTo(selectedTarget).magnitude)
                selectedTarget = target;
            
        }
        return selectedTarget;
    }

    private Vector3 GetDirectionTo(Transform target) => target.position - _source.position;
 
}
