using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleportProgram : MonoBehaviour
{

    [SerializeField] Transform teleportTo;

    public void TeleportPlayerTo()
    {
        FirstPersonController.Instance.gameObject.transform.position = teleportTo.transform.position;
    }
}
