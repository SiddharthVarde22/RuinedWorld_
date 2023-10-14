using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour, IGameService
{
    private Vector3 inputDirection = Vector3.zero;

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public Vector3 InputDirection {
        get
        {
            return inputDirection;
        }
    }

    public void RegisterService(TypesOfServices typesOfService, IGameService gameService)
    {
        ServiceLocator.Instance.RegisterService<InputService>(typesOfService, (InputService)gameService);
    }

    private void OnEnable()
    {
        RegisterService(TypesOfServices.InputService, this);
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        inputDirection.x = HorizontalInput;
        inputDirection.y = 0;
        inputDirection.z = VerticalInput;
    }
}
