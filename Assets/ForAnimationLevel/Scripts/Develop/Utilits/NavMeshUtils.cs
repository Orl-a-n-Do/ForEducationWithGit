using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUtils : MonoBehaviour
{

    public static float GetPathLength(NavMeshPath path)
    {
        float pathLength = 0;

        if(path.corners.Length > 1)
            for(int i = 1; i < path.corners.Length; i++) 
                pathLength += Vector3.Distance(path.corners[i - 1], path.corners[i]);

        return  pathLength;      
    }



   public static bool TryGetPass(Vector3 sourcePosition, Vector3 targetPosition, NavMeshQueryFilter queryFilter, NavMeshPath pathToTarget)
   {
        if(NavMesh.CalculatePath(sourcePosition, targetPosition, queryFilter, pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
                return true;

        return false;
   }

    public static bool TryGetPass(NavMeshAgent agent, Vector3 targetPosition, NavMeshPath pathToTarget)
    {
        if (agent.CalculatePath(targetPosition, pathToTarget ) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
            return true;

        return false;
    }



}
