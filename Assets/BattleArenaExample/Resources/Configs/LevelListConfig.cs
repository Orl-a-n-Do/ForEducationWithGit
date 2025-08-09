using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelListConfig", menuName = "Configs/GamePlay/LevelListConfig", order = 1)]
public class LevelListConfig : ScriptableObject
{
    [SerializeField] private List<LevelConfig> _levelConfigs;
    public LevelConfig GetRandom() => _levelConfigs[Random.Range(0, _levelConfigs.Count)];
    



}
