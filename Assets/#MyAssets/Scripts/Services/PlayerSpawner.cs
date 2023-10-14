using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour, IGameService
{
    [SerializeField]
    private PlayerModelDataScriptableObject playerModelScriptableObject;
    [SerializeField]
    private PlayerView playerView;

    private void OnEnable()
    {
        RegisterService(TypesOfServices.PlayerSpawner, this);
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PlayerController playerController = new PlayerController(playerModelScriptableObject, playerView);
    }

    public void RegisterService(TypesOfServices typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegisterService<PlayerSpawner>(typesOfService, (PlayerSpawner)gameService);
    }
}
