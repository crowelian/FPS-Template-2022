using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SimpleComputer : MonoBehaviour, IInteractable
{

    [SerializeField] TMP_Text onScreenText;
    [SerializeField] string okMsg = "Ok!";
    [SerializeField] string errorMsg = "Error!";
    [SerializeField] string welcomeMsg = "Welcome!";
    [SerializeField] string interactText = "Use computer";
    [SerializeField] UnityEvent computerEvent;

    // Start is called before the first frame update
    void Start()
    {
        if (onScreenText) onScreenText.text = welcomeMsg;
    }

    public void UseComputer()
    {
        onScreenText.text = okMsg;
        if (computerEvent != null)
        {
            try
            {
                computerEvent.Invoke();
            }
            catch
            {
                onScreenText.text = errorMsg;
            }

            return;
        }

    }

    public void Interact(Transform interactorTransform)
    {
        UseComputer();
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
