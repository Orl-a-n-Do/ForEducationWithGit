using UnityEngine;
using System.Collections;
using Cinemachine;

public class Bootstrap : MonoBehaviour
{
    
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private ConfirmPopup _confirmPopup;

    private ControllersUpdateService _controllersUpdateService;
    private GamePlayCycle _gamePlayCycle;


    private void Awake()
    {
        StartCoroutine(StartProcess());
    }


    private IEnumerator StartProcess()
    {
        _loadingScreen.Show();
        _loadingScreen.ShowMessage("Loading...");

        MainHeroConfig heroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");
        LevelListConfig levelListConfig = Resources.Load<LevelListConfig>("Configs/LevelListConfig");

        if (heroConfig == null)
        {
            Debug.LogError("MainHeroConfig not found");
            yield break;
        }

        if (levelListConfig == null)
        {
            Debug.LogError("LevelListConfig not found");
            yield break;
        }

        _controllersUpdateService = new ControllersUpdateService();



        ControllersFactory controllersFactory = new ControllersFactory();
        CharactersFactory charactersFactory = new CharactersFactory();

        MainHeroFactory mainHeroFactory = new MainHeroFactory(_controllersUpdateService, controllersFactory, charactersFactory);
        EnemiesFactory enemiesFactory = new EnemiesFactory(_controllersUpdateService, controllersFactory, charactersFactory);


        EnemiesSpawner _enemiesSpawner = new EnemiesSpawner(enemiesFactory);

        LevelConfig levelConfig = levelListConfig.GetRandom();

        _gamePlayCycle = new GamePlayCycle(
            mainHeroFactory,
            heroConfig,
            levelConfig,
            _confirmPopup,
            _enemiesSpawner,
            this);

        yield return new WaitForSeconds(1.5f);

        //Подготовка к игре

       


        yield return _gamePlayCycle.Prepare();

        _loadingScreen.Hide();



        // Cтарт игры

        yield return _gamePlayCycle.Launch();


    }


    private void OnDestroy()
    {        
        _gamePlayCycle?.Dispose();
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
        _gamePlayCycle?.Update(Time.deltaTime);

    }

}
 