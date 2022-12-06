using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnvironment : MonoBehaviour
{

    [SerializeField] GameObject environment;
    public GameObject playerTeleportLocation;
    [SerializeField] bool useFog = true;
    [SerializeField] bool useGravity = true;
    [SerializeField] bool hideEnvironmentAtStart = false;
    [SerializeField] bool disableFirstPersonController = false;
    [SerializeField] bool disablePlayerColliders = false;
    [SerializeField] bool hidePlayerGear = false;

    [SerializeField] Transform forcePlayerFollowThis = null;

    void Start()
    {
        if (hideEnvironmentAtStart)
        {
            environment.SetActive(false);
        }
    }

    void LateUpdate()
    {
        if (environment.activeInHierarchy)
        {
            if (forcePlayerFollowThis != null)
            {
                FirstPersonController.Instance.gameObject.transform.position = forcePlayerFollowThis.transform.position;
                // TODO: fix this... make clamped cockpit mouselook!
                //FirstPersonController.Instance.gameObject.transform.rotation = forcePlayerFollowThis.transform.rotation;
            }
        }
    }

    public void EnableEnvironment()
    {
        FirstPersonController.Instance.canControlPlayer = !disableFirstPersonController;
        FirstPersonController.Instance.capsule.enabled = !disablePlayerColliders;
        FirstPersonController.Instance.playerGear.SetActive(hidePlayerGear);
        if (disableFirstPersonController && disablePlayerColliders)
        {
            FirstPersonController.Instance.gameObject.transform.position = playerTeleportLocation.transform.position;
        }

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
