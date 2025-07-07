using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializationTest : MonoBehaviour
{
    [HideInInspector] public int Number;
    [SerializeField] private int _number;


    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private EnemiesSettings _enemiesSettings;

    public float Damage { get; private set; }

    [field: SerializeField] public float Damage2 { get; private set; }


}
