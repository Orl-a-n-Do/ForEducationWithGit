using UnityEngine;
using Cinemachine;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    
    private ControllersUpdateService _controllersUpdateService;
    private ControllersFactory _controllersFactory;


    public void Initialize(
        ControllersUpdateService controllersUpdateService,
        ControllersFactory controllersFactory
         )
    {
        _controllersUpdateService = controllersUpdateService;
        _controllersFactory = controllersFactory;
    }

    public Character Spawn()
    {
        Character instance = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, null);

        instance.Initialize();

        _followCamera.Follow = instance.CameraTarget;



        Controller controller = _controllersFactory.CreateMainHeroPlayerController(instance);
        controller.Enable();

        _controllersUpdateService.Add(controller);
        return instance;
    }
    
}
