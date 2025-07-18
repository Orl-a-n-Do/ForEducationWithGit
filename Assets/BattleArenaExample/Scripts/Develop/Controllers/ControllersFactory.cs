using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersFactory
{
    public PlayerDirectionalMoveableController CreatePlayerDirectionalMoveableController(IDirectionalMoveable movable)
    {
        return new PlayerDirectionalMoveableController(movable);
    }

    public AlongMovableVelocityRotatableController CreateAlongMovableVelocityRotatableController(
        IDirectionalMoveable movable,
        IDirectionRotatable rotatable)
    {
        return new AlongMovableVelocityRotatableController(rotatable, movable);

    }

    public CompositeController CreateMainHeroPlayerController(Character character)
    {
        return new CompositeController(
            CreatePlayerDirectionalMoveableController(character),
            CreateAlongMovableVelocityRotatableController(character, character));
    }
    public AgentCharacterAgroController CreateAgentCharacterAgroController(    
          AgentCharacter character,
          Transform target,
          float agroRange,
          float minDistanceToTarget,
          float timeForIdle)
    {
        return new AgentCharacterAgroController(character, target, agroRange, minDistanceToTarget, timeForIdle);
    } 

}
