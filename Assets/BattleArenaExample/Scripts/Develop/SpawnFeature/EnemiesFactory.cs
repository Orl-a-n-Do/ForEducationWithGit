using UnityEngine;

public class EnemiesFactory
{
    private ControllersUpdateService _controllersUpdateService;
    private ControllersFactory _controllersFactory;
    private CharactersFactory _charactersFactory;

    public EnemiesFactory(
        ControllersUpdateService controllersUpdateService,
        ControllersFactory controllersFactory,
        CharactersFactory charactersFactory)
    {
        _controllersUpdateService = controllersUpdateService;
        _controllersFactory = controllersFactory;
        _charactersFactory = charactersFactory;
    }

    public AgentCharacter CreateAgentEnemy(AgentCharacter prefab, Vector3 spawnPosition, Transform target)
    {   
            AgentCharacter instance = _charactersFactory.CreateAgentCharacter(
                prefab,
                spawnPosition,
                6 ,
                900,
                1);
             
            Controller controller = _controllersFactory.CreateAgentCharacterAgroController(instance, target, 30, 2, 1);


            controller.Enable();

            _controllersUpdateService.Add(controller);

        return instance;

    }






}
