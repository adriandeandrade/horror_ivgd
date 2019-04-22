using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;

    bool isPressingInteractionButton;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        GetInteraction();

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, cam.transform.forward * 5000000, Color.red);
    }

    private void GetInteraction()
    {
        Ray interactionRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay.origin, cam.transform.forward, out interactionInfo, Mathf.Infinity, interactionLayer))
        {
            bool hit = false;

            if (interactionInfo.collider != null)
            {
                hit = true;
            }
            else
            {
                hit = false;
            }

            if (hit)
            {
                //interactionInfo.collider.GetComponent<Interactable>().Interact();
            }
        }
    }
}
