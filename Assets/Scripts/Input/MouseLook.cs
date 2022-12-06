using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float lookSpeed;
    [SerializeField]
    private float aimLookSpeed;
    [SerializeField]
    private float lookXLimit;
    private float rotationX;
    float Xsensitivity = 4f;
    float Ysensitivity = 4f;
    float MinimumX = -90f;
    float MaximumX = 90;

    Quaternion cameraRotation;

    void Awake()
    {
        // cameraRotation = ShittyAimCode.mainCam.transform.localRotation;
    }

    void Start()
    {
        lookSpeed = SettingsManager.Instance.mouseLookSpeed;
        Xsensitivity = SettingsManager.Instance.GetMouseSensitivityX();
        Ysensitivity = SettingsManager.Instance.GetMouseSensitivityY();
    }

    private void Update()
    {
        Look();
    }

    public void Look()
    {
        if (ShittyAimCode.isAiming)
        {
            this.rotationX += -Input.GetAxis("Mouse Y") * this.aimLookSpeed;
            this.rotationX = Mathf.Clamp(this.rotationX, -this.lookXLimit, this.lookXLimit);
            ShittyAimCode.mainCam.transform.localRotation = Quaternion.Euler(this.rotationX, 0.0f, 0.0f);
            this.transform.rotation *= Quaternion.Euler(0.0f, Input.GetAxis("Mouse X") * this.aimLookSpeed, 0.0f);
        }
        else
        {
            this.rotationX += -Input.GetAxis("Mouse Y") * this.lookSpeed;
            this.rotationX = Mathf.Clamp(this.rotationX, -this.lookXLimit, this.lookXLimit);
            ShittyAimCode.mainCam.transform.localRotation = Quaternion.Euler(this.rotationX, 0.0f, 0.0f);
            this.transform.rotation *= Quaternion.Euler(0.0f, Input.GetAxis("Mouse X") * this.lookSpeed, 0.0f);

            // float yRot = Input.GetAxis("Mouse X") * Xsensitivity;
            // float xRot = Input.GetAxis("Mouse Y") * Ysensitivity;

            // cameraRotation *= Quaternion.Euler(-xRot, 0, 0);
            // characterRotation *= Quaternion.Euler(0, yRot, 0);

            // cameraRotation = ClampRotationAroundXAxis(cameraRotation);

            // this.transform.localRotation = characterRotation;
            // cam.transform.localRotation = cameraRotation;
        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
