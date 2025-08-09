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

    public Character Create(
        MainHeroConfig config,
        Vector3 spawnPosition
        )
        
    {
        if (config.Prefab == null)
            throw new System.ArgumentNullException(nameof(config.Prefab), "Character prefab is null");
            
        Character instance = _charactersFactory.CreateCharacter(
            config.Prefab,
            spawnPosition,
            config.moveSpeed,
            config.rotationSpeed);

        CinemachineVirtualCamera followCameraPrefab = Resources.Load<CinemachineVirtualCamera>("FollowCamera");
        CinemachineVirtualCamera followCamera = Object.Instantiate(followCameraPrefab);

        followCamera.Follow = instance.CameraTarget;



        Controller controller = _controllersFactory.CreateMainHeroPlayerController(instance);
        controller.Enable();

        _controllersUpdateService.Add(controller,() => instance.IsDestroyed);
        return instance;

    }
  
}
