using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecoil : MonoBehaviour
{
    [Header("Recoil Settings")]
    public float rotationSpeed = 6f;
    public float returnSpeed = 25f;
    [Space]
    [Header("Hipfire:")]
    public Vector3 RecoilRotation;
    [Space]
    [Header("Aiming")]
    public Vector3 RecoilRotationAiming;
    [Space]
    [Header("State")]
    public bool aiming;
    private Vector3 currentRotation;
    private Vector3 Rot;
    private Transform cameraHolder;

    private void Awake() => this.cameraHolder = gameObject.transform;

    private void FixedUpdate()
    {
        this.currentRotation = Vector3.Lerp(this.currentRotation, Vector3.zero, this.returnSpeed * Time.deltaTime);
        this.Rot = Vector3.Slerp(this.Rot, this.currentRotation, this.rotationSpeed * Time.fixedDeltaTime);
        this.cameraHolder.localRotation = Quaternion.Euler(this.Rot);
    }

    public void Fire()
    {
        if (this.aiming)
            this.currentRotation += new Vector3(-this.RecoilRotationAiming.x, Random.Range(-this.RecoilRotationAiming.y, this.RecoilRotationAiming.y), Random.Range(-this.RecoilRotationAiming.z, this.RecoilRotationAiming.z));
        else
            this.currentRotation += new Vector3(-this.RecoilRotation.x, Random.Range(-this.RecoilRotation.y, this.RecoilRotation.y), Random.Range(-this.RecoilRotation.z, this.RecoilRotation.z));
    }
}
