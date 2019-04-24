using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    // Public Variables
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private bool interactOnce;

    // Events
    [SerializeField] private UnityEvent OnInteract;

    // Private Variables
    bool hasInteracted = false;
    bool active;

    // Components

    private void Awake()
    {
        DeactivateInteractionUI();

        if (OnInteract == null)
        {
            OnInteract = new UnityEvent();
        }
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            Debug.Log("Interacted");

            if (interactOnce)
                hasInteracted = true;

            OnInteract.Invoke(); // Fire an function tied to this event.
        }
        else
        {
            Debug.Log("Has already interacted!");
        }
    }

    public void ActivateInteractionUI()
    {
        interactionUI.SetActive(true);
    }

    public void DeactivateInteractionUI()
    {
        interactionUI.SetActive(false);
    }
}
