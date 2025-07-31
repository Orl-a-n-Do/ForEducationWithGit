using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

public class CharactersFactory
{
    public Character CreateCharacter(
        Character prefab,
        Vector3 spawnPosition,
        float moveSpeed,
        float rotationSpeed
        )
    {
        Character instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);

        DirectionalMover mover;
        DirectionalRotator rotator;

        // if (instance.TryGetComponent(out NavMeshAgent agent))
        // {
        //     _agent = agent;
        //     // Если нужно управлять агентом вручную, можно добавить свой AgentMover и Rotator
        //     // _mover = new AgentMover(_agent, _moveSpeed);
        //     // _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        // }

        if (instance.TryGetComponent(out CharacterController characterController))
        {
            mover = new CharacterControllerDirectionalMover(characterController, moveSpeed);
            rotator = new TransformDirectionalRotator(instance.transform, rotationSpeed);
        }
        else if (instance.TryGetComponent(out Rigidbody rigidbody))
        {
            mover = new RigidBodyDirectionalMover(rigidbody, moveSpeed);
            rotator = new RigidBodyDirectionalRotator(rigidbody, rotationSpeed);
        }
        else
        {
            throw new InvalidOperationException("Не найден компонент передвижения на обьекте");
        }

        instance.Initialize(mover, rotator);
        return instance;

    }


    public AgentCharacter CreateAgentCharacter(
         AgentCharacter prefab,
         Vector3 spawnPosition,
         float moveSpeed,
         float rotationSpeed,
         float timeToSpawn
         )
    {
        AgentCharacter instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity, null);

        NavMeshAgent agent;

        if (instance.TryGetComponent(out agent) == false)
            throw new InvalidOperationException("Не найден компонент NavMeshAgent на обьекте");

        agent.updateRotation = false;

        AgentMover mover = new AgentMover(agent, moveSpeed);
        TransformDirectionalRotator rotator = new TransformDirectionalRotator(instance.transform, rotationSpeed);

        Timer spawnTimer = new Timer(instance);

        instance.Initialize(
            agent,
            mover,
            rotator,
            spawnTimer,
            timeToSpawn);

        return instance;

    }   
   




}
