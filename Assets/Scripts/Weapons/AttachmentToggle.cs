using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentToggle : MonoBehaviour
{

    // Todo fix this
    public KeyCode toggleAttachmentKey = InputManager.Instance.toggleAttachment1; // TODO: fix this!

    // TODO fix also this
    [SerializeField] GameObject toggleMe;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(toggleAttachmentKey))
        {
            toggleMe.SetActive(toggleMe.activeInHierarchy ? false : true);
        }
    }
}
