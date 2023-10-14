using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    string inputSpeedParameterName = "InputSpeed";

    int inputSpeedHash;
    float absoluteInputSpeed = 0;

    private InputService inputService;

    private void Start()
    {
        inputSpeedHash = Animator.StringToHash(inputSpeedParameterName);
    }

    private void Update()
    {
        if(inputService == null)
        {
            inputService = ServiceLocator.Instance.GetService<InputService>(TypesOfServices.InputService);
        }
        else
        {
            absoluteInputSpeed = inputService.InputDirection.magnitude;
            playerAnimator.SetFloat(inputSpeedHash, absoluteInputSpeed);
        }
    }
}
