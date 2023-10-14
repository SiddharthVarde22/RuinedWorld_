using Cinemachine;
using UnityEngine;

public class VirtualCameraBehavior : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    EventService gameEventService;
    Transform playerTransform;

    private void Start()
    {
        gameEventService = ServiceLocator.Instance.GetService<EventService>(TypesOfServices.EventService);
        if(gameEventService != null)
        {
            gameEventService.OnPlayerSpawnEvent += OnPlayerSpawnedCalled;
            gameEventService.OnPlayerDiedEvent += OnPlayerDiedCalled;
        }
    }

    public void OnPlayerSpawnedCalled()
    {
        playerTransform = ServiceLocator.Instance.GetService<WorldObjectHolderService>
            (TypesOfServices.WorldObjectHolder)?.playerRefrence.transform;

        SetPlayerTargetToFollow();
    }

    private void SetPlayerTargetToFollow()
    {
        virtualCamera.Follow = playerTransform;
        virtualCamera.LookAt = playerTransform;
    }

    public void OnPlayerDiedCalled()
    {
        playerTransform = null;
        RemovePlayerTargetTofollow();
    }

    private void RemovePlayerTargetTofollow()
    {
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
    }

    private void OnDestroy()
    {
        if(gameEventService != null)
        {
            gameEventService.OnPlayerSpawnEvent -= OnPlayerSpawnedCalled;
            gameEventService.OnPlayerDiedEvent -= OnPlayerDiedCalled;
        }
    }
}
