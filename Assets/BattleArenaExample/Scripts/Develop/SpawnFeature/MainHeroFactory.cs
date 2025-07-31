using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MainHeroFactory
{
    private ControllersUpdateService _controllersUpdateService;
    private ControllersFactory _controllersFactory;
    private CharactersFactory _charactersFactory;

    public MainHeroFactory(
        ControllersUpdateService controllersUpdateService,
        ControllersFactory controllersFactory,
        CharactersFactory charactersFactory)
    {
        _controllersUpdateService = controllersUpdateService;
        _controllersFactory = controllersFactory;
        _charactersFactory = charactersFactory;
    }

    public Character Create(Character prefab, Vector3 spawnPosition, CinemachineVirtualCamera followCamera)
    {
        Character instance = _charactersFactory.CreateCharacter(prefab, spawnPosition, 9, 900);

        followCamera.Follow = instance.CameraTarget;



        Controller controller = _controllersFactory.CreateMainHeroPlayerController(instance);
        controller.Enable();

        _controllersUpdateService.Add(controller);
        return instance;

    }
  
}
