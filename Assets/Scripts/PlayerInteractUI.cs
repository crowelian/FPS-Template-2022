using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteractUI : MonoBehaviour
{

    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text ammoText;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }


        UpdateGenericUI();
    }

    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }

    void UpdateGenericUI()
    {
        if (healthText != null)
        {
            healthText.text = playerInteract.gameObject.GetComponent<Health>().GetCurrentHealt().ToString("00");
        }
        if (ammoText != null)
        {
            ammoText.text = playerInteract.gameObject.GetComponent<SimpleWeaponHandler>().GetCurrentAmmo().ToString();
        }
    }

}