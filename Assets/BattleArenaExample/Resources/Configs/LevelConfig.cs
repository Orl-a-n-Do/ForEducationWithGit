using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/GamePlay/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public float DistanceTravelledToWin { get; private set; }
    [field: SerializeField] public float TimeToDefeat { get; private set; }
    [field: SerializeField] public AgentEnemyConfig EnemyConfig { get; private set; }
    [field: SerializeField] public int EnemiesCount { get; private set; }
    [field: SerializeField] public int EnemiesSpawnRange { get; private set; }
    [field: SerializeField] public Vector3 MainHeroStartPosition { get; private set; }


    [ContextMenu("Update Start Hero Position")]
    private void UpdateStartHeroPosition()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("StartHeroPosition");
        if (points.Length == 0)
        {
            Debug.LogError("No GameObjects with tag 'StartHeroPosition' found in scene");
            return;
        }
        
        GameObject point = points[0];
        MainHeroStartPosition = point.transform.position;
    }
}
