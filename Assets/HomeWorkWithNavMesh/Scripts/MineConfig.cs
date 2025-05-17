using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Configs/MineConfigs", fileName = "MineConfig")]
public class MineConfig : ScriptableObject
{
    [field: SerializeField] public float ExplosionRadius { get; private set; }
    [field: SerializeField] public float TimeUntilExplosion { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }

}
