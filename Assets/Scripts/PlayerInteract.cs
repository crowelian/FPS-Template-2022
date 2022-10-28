using System.Collections.Generic;
using UnityEngine;

// Based on the tutorial by Code Monkey

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] float interactRange = 4f;
    [SerializeField] KeyCode interactActionKey = KeyCode.E; // fix this to use some input configurer etc...

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(interactActionKey))
        {
            // Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            // foreach (Collider collider in colliderArray)
            // {
            //     Debug.Log(collider);
            // }
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }

    }


    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }



}
