using UnityEngine;

public class AttachmentZoom : MonoBehaviour
{

    [SerializeField] Camera scopeCamera;
    [SerializeField] float zoomedOutFov = 25f;
    [SerializeField] float zoomedInFov = 10f;

    [SerializeField] bool toggledZoom = false;
    private float current, target;
    [SerializeField] float zoomSpeed = 2f;


    void Start()
    {
        // scopeCamera.fieldOfView = toggledZoom ? zoomedInFov : zoomedOutFov;
    }

    void Update()
    {
        if (Input.GetKeyUp(InputManager.Instance.toggleAttachmentZoom))
        {
            toggledZoom = !toggledZoom;
        }
        target = toggledZoom ? 1 : 0;
        current = Mathf.MoveTowards(current, target, zoomSpeed * Time.deltaTime);

        scopeCamera.fieldOfView = Mathf.Lerp(zoomedOutFov, zoomedInFov, current);

    }
}
