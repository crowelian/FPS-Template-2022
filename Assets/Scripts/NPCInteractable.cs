using UnityEngine;

// Based on the tutorial by Code Monkey
public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    [SerializeField] private string messageText;

    //private Animator animator;
    //private NPCHeadLookAt npcHeadLookAt;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        //npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform)
    {
        ChatBubble3D.Create(transform, new Vector3(-.3f, 1.7f, 0f), ChatBubble3D.IconType.Happy, messageText);

        //animator.SetTrigger("Talk");

        //float playerHeight = 1.7f;
        //npcHeadLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);
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
