using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectHolderService : MonoBehaviour, IGameService
{
    public PlayerView playerRefrence { get; private set; }
    public void RegisterService(TypesOfServices typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegisterService<WorldObjectHolderService>(typesOfService, (WorldObjectHolderService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfServices.WorldObjectHolder, this);
    }

    public void SetPlayerRefrence(PlayerView playerView)
    {
        playerRefrence = playerView;
        ServiceLocator.Instance.GetService<EventService>(TypesOfServices.EventService)?.OnPlayerSpawnEventTrigger();
    }
}
