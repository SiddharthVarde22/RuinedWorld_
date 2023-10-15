using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    string inputSpeedParameterName = "InputSpeed", attackTriggerParameterName = "Attack";

    int inputSpeedHash, attackTriggerHash;
    float absoluteInputSpeed = 0;

    private InputService inputService;

    private void Start()
    {
        inputSpeedHash = Animator.StringToHash(inputSpeedParameterName);
        attackTriggerHash = Animator.StringToHash(attackTriggerParameterName);
    }

    private void Update()
    {
        if (inputService == null)
        {
            inputService = ServiceLocator.Instance.GetService<InputService>(TypesOfServices.InputService);
            inputService.OnAttackButtonPressedEvent += OnAttackPressedEventTriggered;
        }
        else
        {
            PlayMovementAnimation();
        }
    }

    private void PlayMovementAnimation()
    {
        absoluteInputSpeed = inputService.InputDirection.magnitude;
        playerAnimator.SetFloat(inputSpeedHash, absoluteInputSpeed);
    }

    private void OnAttackPressedEventTriggered()
    {
        playerAnimator.SetTrigger(attackTriggerHash);
    }

    private void OnDestroy()
    {
        inputService.OnAttackButtonPressedEvent -= OnAttackPressedEventTriggered;
    }

    public void EnablePlayerMovements()
    {
        inputService.EnableMovements();
    }

    public void DisablePlayerMovements()
    {
        inputService.DisableMovements();
    }
}
