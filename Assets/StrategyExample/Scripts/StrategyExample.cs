using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyExample : MonoBehaviour
{
    [SerializeField] private EnemyMoving _enemyMPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Transform> _targets;

    private List<EnemyMoving>_spawnedEnemies = new ();


   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnemyMoving character = CreateCharacter();
            character.Initialize(new HighetsTargetSelector(), _targets);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
         {
            EnemyMoving character = CreateCharacter();
            character.Initialize(new LowerTargetSelector(), _targets);
        }
         if(Input.GetKeyDown(KeyCode.Alpha3))
         {
            EnemyMoving character = CreateCharacter();
            character.Initialize(new DistanceTargetSellector(character.transform), _targets);
        }
    }

    private EnemyMoving CreateCharacter()
    {
        EnemyMoving character = Instantiate(_enemyMPrefab, _spawnPoint.position, Quaternion.identity);
        _spawnedEnemies.Add(character);
        return character;
    }



}
