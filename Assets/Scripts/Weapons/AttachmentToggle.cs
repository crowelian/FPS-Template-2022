using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attachment))]
public class AttachmentToggle : MonoBehaviour
{

    // Todo fix this
    [SerializeField] private KeyCode toggleAttachmentKey;

    public List<KeyCodeValuePair> keys;

    // TODO fix also this
    [SerializeField] GameObject toggleMe;

    void Start()
    {
        keys = InputManager.Instance.KeycodesList;
        foreach (var x in keys)
        {
            if (GetComponent<Attachment>().attachmentName == x.key)
            {
                toggleAttachmentKey = x.value;
                break;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(toggleAttachmentKey))
        {
            toggleMe.SetActive(toggleMe.activeInHierarchy ? false : true);
        }
    }
}
