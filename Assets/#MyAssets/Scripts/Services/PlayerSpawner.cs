using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private PlayerModelDataScriptableObject playerModelScriptableObject;
    [SerializeField]
     private PlayerView playerView;

    void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        PlayerController playerController = new PlayerController(playerModelScriptableObject, playerView);
    }
}
