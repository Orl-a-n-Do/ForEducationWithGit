using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainHeroConfig", menuName = "Configs/GamePlay/MainHeroConfig")]
public class MainHeroConfig : ScriptableObject
{
    [field: SerializeField] public Character Prefab { get; private set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 9;
    [field: SerializeField] public float rotationSpeed { get; private set; } = 900;
}
