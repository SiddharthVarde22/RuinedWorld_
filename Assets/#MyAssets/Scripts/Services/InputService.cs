using System;
using UnityEngine;

public class InputService : MonoBehaviour, IGameService
{
    private bool canMove = true;
    public event Action OnAttackButtonPressedEvent;

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
        if (canMove)
        {
            TakeMovementInput();
        }
        TakeAttackInput();
    }

    private void TakeMovementInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        SetInputDirection();
    }

    private void SetInputDirection()
    {
        inputDirection.x = HorizontalInput;
        inputDirection.y = 0;
        inputDirection.z = VerticalInput;
    }

    private void TakeAttackInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            OnAttackPressedEventTrigger();
        }
    }
    private void OnAttackPressedEventTrigger()
    {
        OnAttackButtonPressedEvent?.Invoke();
    }

    public void DisableMovements()
    {
        canMove = false;
        HorizontalInput = 0;
        VerticalInput = 0;

        SetInputDirection();
    }

    public void EnableMovements()
    {
        canMove = true;
    }
}
