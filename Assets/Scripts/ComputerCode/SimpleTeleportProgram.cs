using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleportProgram : MonoBehaviour
{

    [SerializeField] Environment environment;


    public void TeleportPlayerTo()
    {
        if (environment)
        {
            environment.EnableEnvironment();
        }
        if (environment.playerTeleportLocation)
        {
            FirstPersonController.Instance.gameObject.transform.position = environment.playerTeleportLocation.transform.position;
        }
    }
}
