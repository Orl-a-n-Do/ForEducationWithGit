using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBootstrap : MonoBehaviour
{
    [SerializeField] private Mine _minePrefab;

    [SerializeField] private MineConfig _lightMine;
    [SerializeField] private MineConfig _hardMine;


    [SerializeField] private Transform _placeForLightMine;
    [SerializeField] private Transform _placeForHardMine;

    private void Start()
    {
        CreateMine(_placeForLightMine.position, _lightMine);
        CreateMine(_placeForHardMine.position, _hardMine);
    }

    private Mine CreateMine(Vector3 position, MineConfig config)
    {
        Mine instance = Instantiate(_minePrefab, position, Quaternion.identity);
        instance.Initialize(
            config.ExplosionRadius,
            config.TimeUntilExplosion,
            config.Damage);
        return instance;

    }

}
    