using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameMode
{
    public event Action Win;
    public event Action Defeat;

    private LevelConfig _levelConfig;


    private float _currentDistanceTraveled;
    private float _currentTimeToDefeat;

    private Character _mainHero;
    private Vector3 _previousHeroPosition;

    private EnemiesSpawner _enemiesSpawner;
    private bool _isRunning;

    private List<AgentCharacter> _spawnedEnemies;


    public GameMode(
        LevelConfig levelConfig,
        Character mainHero,
        EnemiesSpawner enemiesSpawner)
    {
        _levelConfig = levelConfig;
        _mainHero = mainHero;
        _enemiesSpawner = enemiesSpawner;
    }

    public void Start()
    {
        _currentTimeToDefeat = _levelConfig.TimeToDefeat;
        _currentDistanceTraveled = 0;

        _previousHeroPosition = _mainHero.transform.position;

       _spawnedEnemies = _enemiesSpawner.Spawn(
            _levelConfig.EnemyConfig,
            _mainHero.transform,
            _levelConfig.EnemiesSpawnRange,
            _levelConfig.EnemiesCount);

        _isRunning = true;

    }

    public void Update(float deltaTime)
    {
        if (_isRunning == false)
            return;

        ProcessCountingDefeateTime(deltaTime);

        if (DefeatConditionCompleted())
        {
            ProcessDefeate();
            return;
        }

        ProcessCountingCurrentDistanceTravelled();

        if(WinConditionCompleted())
        {
            ProcessWin();
            return;
        }



    }

    private void ProcessCountingDefeateTime(float deltaTime)
    {

        _currentTimeToDefeat -= deltaTime;

    }

    private void ProcessCountingCurrentDistanceTravelled()
    {
        _currentDistanceTraveled += (_mainHero.transform.position - _previousHeroPosition).magnitude;
        _previousHeroPosition = _mainHero.transform.position;
        
    }

    private void ProcessEndGame()
    {

        _isRunning = false;


        foreach (AgentCharacter enemy in _spawnedEnemies)
            enemy.Destroy();
            
        _spawnedEnemies.Clear();


    }

    private void ProcessDefeate()
    {

        ProcessEndGame();
        Defeat?.Invoke();
    }


    private void ProcessWin()
    {
        ProcessEndGame();
        Win?.Invoke();
    }




    private bool WinConditionCompleted() => _currentDistanceTraveled >= _levelConfig.DistanceTravelledToWin; 

    private bool DefeatConditionCompleted() => _currentTimeToDefeat <= 0;
    
        
    



}
