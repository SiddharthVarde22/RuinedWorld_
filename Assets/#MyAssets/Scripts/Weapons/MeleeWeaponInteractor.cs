using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponInteractor : MonoBehaviour, IInteractable
{
    [SerializeField]
    BoxCollider interactorTrigger;

    public void OnInteractonHappened(PlayerView playerView)
    {
        PlayerAnimationController playerAnimationController = playerView.GetComponent<PlayerAnimationController>();

        transform.parent = playerView.GetMeleeWeaponHolderTransform();
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        playerAnimationController.OnMeleeWeaponPickup();
        interactorTrigger.enabled = false;
    }
}
