using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



[Serializable]
public class EnemiesSettings
{
    [SerializeField] private List<EnemyConfig> _enemyConfigs;
    public float GetDamageBy(EnemyType enemyType)
            => _enemyConfigs.First(config => config.Type == enemyType).Damage;


    [Serializable]
    private class EnemyConfig
    {

        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }

    }


}
