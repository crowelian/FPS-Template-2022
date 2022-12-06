using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] bool disablePlayerCamera = false;

    [SerializeField] Transform forcePlayerFollowThis = null;

    [SerializeField] UnityEvent customStartEvent;

    void Start()
    {
        if (hideEnvironmentAtStart)
        {
            environment.SetActive(false);
        }
    }

    void Update()
    {
        if (environment.activeInHierarchy)
        {
            if (forcePlayerFollowThis != null)
            {
                // FirstPersonController.Instance.gameObject.transform.position = forcePlayerFollowThis.transform.position;
                // FirstPersonController.Instance.gameObject.transform.rotation = forcePlayerFollowThis.transform.rotation;


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
            FirstPersonController.isWalking = false; // TODO: fix


            FirstPersonController.Instance.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            if (forcePlayerFollowThis)
            {
                FirstPersonController.Instance.gameObject.transform.SetParent(forcePlayerFollowThis);
            }
        }
        else
        {
            FirstPersonController.Instance.gameObject.transform.SetParent(null);
            FirstPersonController.Instance.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }

        FirstPersonController.Instance.SetPlayerCameraEnabled(!disablePlayerCamera);

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

        if (customStartEvent != null)
        {
            try
            {
                customStartEvent.Invoke();
            }
            catch
            {
                Debug.LogError("Error with customStartEvent");
            }

            return;
        }


    }

}
