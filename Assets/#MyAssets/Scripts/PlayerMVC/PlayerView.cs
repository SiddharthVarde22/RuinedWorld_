using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;
    private InputService inputService;

    public Rigidbody playerRigidBody;

    private void Start()
    {
        GetPlayerRigidbody();
        ServiceLocator.Instance.GetService<WorldObjectHolderService>
            (TypesOfServices.WorldObjectHolder)?.SetPlayerRefrence(this);
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void Update()
    {
        if (inputService == null)
        {
            inputService = ServiceLocator.Instance.GetService<InputService>(TypesOfServices.InputService);
        }
        else
        {
            if (inputService.HorizontalInput != 0 || inputService.VerticalInput != 0)
            {
                MovePlayer();
            }
        }
    }

    private void MovePlayer()
    {
        playerController.MovePlayer(inputService.InputDirection);
    }

    private void GetPlayerRigidbody()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }
}
