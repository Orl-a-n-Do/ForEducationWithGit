using UnityEngine;
using System.Collections;
using Cinemachine;

public class Bootstrap : MonoBehaviour
{
    
    [SerializeField] private float _radius;
    [SerializeField] private int _count;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private ConfirmPopup _confirmPopup;

    private ControllersUpdateService _controllersUpdateService;

    private void Awake()
    {

        StartCoroutine(StartProcess());

    }


    private IEnumerator StartProcess()
    {
        _loadingScreen.Show();
        _loadingScreen.ShowMessage("Loading...");

        MainHeroConfig heroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");
        AgentEnemyConfig enemyConfig = Resources.Load<AgentEnemyConfig>("Configs/AgentEnemyConfig");


        _controllersUpdateService = new ControllersUpdateService();



        ControllersFactory controllersFactory = new ControllersFactory();
        CharactersFactory charactersFactory = new CharactersFactory();

        MainHeroFactory mainHeroFactory = new MainHeroFactory(_controllersUpdateService, controllersFactory, charactersFactory);
        EnemiesFactory enemiesFactory = new EnemiesFactory(_controllersUpdateService, controllersFactory, charactersFactory);


        EnemiesSpawner _enemiesSpawner = new EnemiesSpawner(enemiesFactory);
        

        yield return new WaitForSeconds(1.5f);

        //Подготовка к игре
        Character mainHero = mainHeroFactory.Create(heroConfig, _spawnPoint.position, _followCamera);


        _loadingScreen.Hide();
        _confirmPopup.Show();
        _confirmPopup.ShowMessage($"Press{KeyCode.F.ToString()} for begin");

        yield return _confirmPopup.WaitConfirm(KeyCode.F);

        _confirmPopup.Hide();
        // Cтарт игры

        _enemiesSpawner.Spawn(enemyConfig, mainHero.transform, _radius, _count);
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
    }

}
 