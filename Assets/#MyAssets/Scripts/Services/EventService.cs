using System;
using UnityEngine;

public class EventService : MonoBehaviour, IGameService
{
    public event Action OnPlayerSpawnEvent;
    public event Action OnPlayerDiedEvent;
    public void RegisterService(TypesOfServices typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegisterService<EventService>(typesOfService, (EventService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfServices.EventService, this);
    }

    public void OnPlayerSpawnEventTrigger()
    {
        OnPlayerSpawnEvent?.Invoke();
    }

    public void OnPlayerDiewEventTrigger()
    {
        OnPlayerDiedEvent?.Invoke();
    }
}
