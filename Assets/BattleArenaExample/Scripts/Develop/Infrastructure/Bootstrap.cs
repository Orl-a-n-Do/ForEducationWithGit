using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainHeroSpawner _mainHeroSpawner;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private ConfirmPopup _confirmPopup;

    private void Awake()
    {

        StartCoroutine(StartProcess());

    }


    private IEnumerator StartProcess()
    {
        _loadingScreen.Show();
        _loadingScreen.ShowMessage("Loading...");



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

}
 