using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentEnemyConfig", menuName = "Configs/GamePlay/AgentEnemyConfig")]
public class AgentEnemyConfig : ScriptableObject
{
    [field: SerializeField] public AgentCharacter Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; } = 9;
    [field: SerializeField] public float RotationSpeed { get; private set; } = 900;

    [field: SerializeField] public float TimeToSpawn { get; private set; } = 900;
    [field: SerializeField] public float AgroRange { get; private set; } = 30;
    [field: SerializeField] public float TimeToIdle { get; private set; } = 1;
    [field: SerializeField] public float MinDistanceToTarget { get; private set; } = 5;

}
