using UnityEngine;
using Cinemachine;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;


    private MainHeroFactory _mainHeroFactory;


    public void Initialize(MainHeroFactory mainHeroFactory)
    {

        _mainHeroFactory = mainHeroFactory;

    }

    public Character Spawn() => _mainHeroFactory.Create(_prefab, _spawnPoint.position, _followCamera);
    
    
}
