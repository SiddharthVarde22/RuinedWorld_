using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private PlayerController playerController;
    public PlayerModelDataScriptableObject playerDataScriptable { get; private set; }

    public PlayerModel(PlayerModelDataScriptableObject playerDataScriptable, PlayerController playerController)
    {
        this.playerController = playerController;
        this.playerDataScriptable = playerDataScriptable;
    }
}
