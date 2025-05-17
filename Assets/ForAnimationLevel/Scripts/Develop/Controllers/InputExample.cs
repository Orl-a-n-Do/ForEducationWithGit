using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
   [SerializeField] private Character _character;
  // [SerializeField] private Character _enemy;
  // [SerializeField] private AgentCharacter _agentEnemy;
   
   private Controller _characterController;
   private Controller _enemyController;
   private Controller _agentEnemyController;

   private Controller _characterPointAndClickController;



    private NavMeshPath _path;



    private void Awake()
    {
        _path = new NavMeshPath();

        _characterController = new CompositeController(
            new PlayerDirectionalMoveableController(_character),
            new AlongMovableVelocityRotatableController(_character, _character));


        _characterController.Enable();


        NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
        queryFilter.agentTypeID = 0;
        queryFilter.areaMask = NavMesh.AllAreas;

        // _enemyController = new CompositeController(
        //     new DirectionalMovableAgroController(_enemy, _character.transform, 30, 2, queryFilter, 1),
        //     new AlongMovableVelocityRotatableController(_enemy, _enemy));

        // _enemyController.Enable();

        // _agentEnemyController = new AgentCharacterAgroController(_agentEnemy, _character.transform, 30, 2, 1);

        // _agentEnemyController.Enable();

        _characterPointAndClickController = new CompositeController(
        new DiractionalMoveablePointAndClickController(
        _character, // Объект, который реализует IDirectionalMoveable
        Camera.main.transform, // Цель для кликов (например, камера)
        new NavMeshQueryFilter { areaMask = NavMesh.AllAreas } // Фильтр NavMesh
        ));
        _characterPointAndClickController.Enable();

    }

    private void Start()
    {
        //_enemy.gameObject.SetActive(false);
    }


    private void Update()
    {
        _characterController.Update(Time.deltaTime);

        _enemyController.Update(Time.deltaTime);

        _agentEnemyController.Update(Time.deltaTime);

        _characterPointAndClickController.Update(Time.deltaTime);
    }

}
