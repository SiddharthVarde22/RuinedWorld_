using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerModel playerModel;
    private PlayerView playerView;

    public PlayerController(PlayerModelDataScriptableObject playerDataScriptable, PlayerView playerView)
    {
        this.playerModel = new PlayerModel(playerDataScriptable, this);
        this.playerView = GameObject.Instantiate<PlayerView>(playerView);
        playerView.SetPlayerController(this);
    }
}
