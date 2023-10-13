using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private PlayerController playerController;
    private PlayerModelDataScriptableObject playerDataScriptable;

    public PlayerModel(PlayerModelDataScriptableObject playerDataScriptable, PlayerController playerController)
    {
        this.playerController = playerController;
        this.playerDataScriptable = playerDataScriptable;
    }
}
