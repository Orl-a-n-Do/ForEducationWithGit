using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainHeroSpawner _mainHeroSpawner;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
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


        _controllersUpdateService = new ControllersUpdateService();



        ControllersFactory controllersFactory = new ControllersFactory();
        CharactersFactory charactersFactory = new CharactersFactory();

        MainHeroFactory mainHeroFactory = new MainHeroFactory(_controllersUpdateService, controllersFactory, charactersFactory);
        EnemiesFactory enemiesFactory = new EnemiesFactory(_controllersUpdateService, controllersFactory, charactersFactory);


        _mainHeroSpawner.Initialize(mainHeroFactory);
        _enemiesSpawner.Initialize(enemiesFactory);

        yield return new WaitForSeconds(1.5f);

        //Подготовка к игре
        Character mainHero = _mainHeroSpawner.Spawn();


        _loadingScreen.Hide();
        _confirmPopup.Show();
        _confirmPopup.ShowMessage($"Press{KeyCode.F.ToString()} for begin");

        yield return _confirmPopup.WaitConfirm(KeyCode.F);

        _confirmPopup.Hide();
        // Cтарт игры

        _enemiesSpawner.Spawn(mainHero.transform);
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
    }

}
 