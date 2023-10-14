using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerModel playerModel;
    private PlayerView playerView;
    Transform playerTransform;

    public PlayerController(PlayerModelDataScriptableObject playerDataScriptable, PlayerView playerView)
    {
        this.playerModel = new PlayerModel(playerDataScriptable, this);
        this.playerView = GameObject.Instantiate<PlayerView>(playerView);
        this.playerView.SetPlayerController(this);
        this.playerTransform = this.playerView.transform;
    }

    public void MovePlayer(Vector3 direction)
    {
        RotatePlayer(direction);
        playerView.playerRigidBody.MovePosition(playerTransform.position +
            (playerModel.playerDataScriptable.MovementSpeed * Time.deltaTime * playerTransform.forward));
    }

    void RotatePlayer(Vector3 direction)
    {
        playerTransform.rotation = Quaternion.LookRotation(direction);
    }
}
