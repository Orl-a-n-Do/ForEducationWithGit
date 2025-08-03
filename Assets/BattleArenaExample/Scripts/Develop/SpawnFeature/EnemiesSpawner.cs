using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemiesSpawner 
{
   

    private EnemiesFactory _enemiesFactory;


    public EnemiesSpawner(EnemiesFactory enemiesFactory)
    {
        _enemiesFactory = enemiesFactory;
        
    }

    public void Spawn(
        AgentEnemyConfig enemyConfig,
        Transform target,
        float radius,
        float count)
    {
        Vector3 positionAroundTarget;
        NavMeshHit spawnPoint;

        NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
        queryFilter.agentTypeID = 0;
        queryFilter.areaMask = 1;

        for (int i = 0; i < count; i++)
        {
            do
            {
                Vector2 randomPositionCircle = Random.insideUnitCircle * radius;
                Vector3 offset = new Vector3(randomPositionCircle.x, 0, randomPositionCircle.y);

                positionAroundTarget = target.position + offset;
            } while (NavMesh.SamplePosition(positionAroundTarget, out spawnPoint, 0.1f, queryFilter) == false);

            _enemiesFactory.CreateAgentEnemy(enemyConfig, spawnPoint.position, target);
        }
    }
   
}
