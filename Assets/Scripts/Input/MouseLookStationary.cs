using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookStationary : MonoBehaviour
{
    [Header(" ")]
    [Header("Attach this to player camera. Not the player itself.")]
    [Header(" ")]
    [SerializeField] private float lookSpeed;

    [SerializeField] private float lookXLimit;
    [SerializeField] private float lookYLimit;
    private float rotationX;
    private float rotationY;
    float Xsensitivity = 4f;
    float Ysensitivity = 4f;
    float MinimumX = -90f;
    float MaximumX = 90;

    Quaternion cameraRotation;

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

        this.rotationX += -Input.GetAxis("Mouse Y") * this.lookSpeed * Time.deltaTime;
        if (lookXLimit != -1) this.rotationX = Mathf.Clamp(this.rotationX, -this.lookXLimit, this.lookXLimit);
        this.rotationY += Input.GetAxis("Mouse X") * this.lookSpeed * Time.deltaTime;
        if (lookYLimit != -1) this.rotationY = Mathf.Clamp(this.rotationY, -this.lookYLimit, this.lookYLimit);

        this.transform.rotation = Quaternion.Euler(this.rotationX, this.rotationY, 0.0f);
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
