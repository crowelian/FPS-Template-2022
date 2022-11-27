using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{

    [SerializeField] GameObject environment;
    public GameObject playerTeleportLocation;
    [SerializeField] bool useFog = true;
    [SerializeField] bool useGravity = true;
    [SerializeField] bool hideEnvironmentAtStart = false;

    void Start()
    {
        if (hideEnvironmentAtStart)
        {
            environment.SetActive(false);
        }
    }

    public void EnableEnvironment()
    {
        if (useFog)
        {
            GraphicalSettings.Instance.EnableFog();
        }
        else
        {
            GraphicalSettings.Instance.DisableFog();
        }

        if (useGravity)
        {
            // TODO fix this
            FirstPersonController.Instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            // TODO fix this
            FirstPersonController.Instance.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }


        if (environment)
        {
            environment.SetActive(true);
        }

    }

}
