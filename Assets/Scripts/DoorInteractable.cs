using UnityEngine;

// Based on the tutorial by Code Monkey

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText = "Open/Close Door";
    private Animator animator;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen); // Todo! Fix this... might be animation, might be function...
    }

    public void Interact(Transform interactorTransform)
    {
        ToggleDoor();
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}