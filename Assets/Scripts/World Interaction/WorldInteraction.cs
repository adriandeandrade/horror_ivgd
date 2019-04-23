using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private float interactionDistance;

    bool canInteract;

    Camera cam;
    InteractableObject lastObjectInteracted;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        GetInteraction();

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, cam.transform.forward * 5000000, Color.red);

        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                lastObjectInteracted.Interact();
            }
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay.origin, cam.transform.forward, out interactionInfo, Mathf.Infinity, interactionLayer))
        {
            if (interactionInfo.collider != null)
            {
                lastObjectInteracted = interactionInfo.collider.GetComponent<InteractableObject>();
                float distanceToObject = GetDistance(interactionInfo.collider.transform.position);
                if (distanceToObject <= interactionDistance)
                {
                    canInteract = true;
                    lastObjectInteracted.ActivateInteractionUI();
                }
                else
                {
                    canInteract = false;
                    lastObjectInteracted.DeactivateInteractionUI();
                }
            }
        }
        else
        {
            if(lastObjectInteracted != null)
            {
                canInteract = false;
                lastObjectInteracted.DeactivateInteractionUI();
            }
        }
    }

    private float GetDistance(Vector3 objectPos)
    {
        return Vector3.Distance(transform.position, objectPos);
    }
}
