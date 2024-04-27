using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] GameObject iPrompt;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] private float interactionDistance = 2.15f;
    [SerializeField] private LayerMask interlayer;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interlayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                iPrompt.SetActive(true);
                text.SetText(interactable.item.verb + " " + interactable.item.itemName);
                if (Input.GetKeyDown(KeyCode.E)) interactable.interact();
            }
        }
        else iPrompt.SetActive(false);
    }

    // Draw Gizmos for debugging purposes
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * interactionDistance);
    }
}
