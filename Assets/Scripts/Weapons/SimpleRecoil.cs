using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{
    [SerializeField] Vector3 upRecoil;
    [SerializeField] float maxRecoilAngle;
    [SerializeField] float maxAimingRecoilAngle;
    [SerializeField] float recoilDampeningTime = 11f;
    Vector3 originalRotation;
    Vector3 recoilRotation;
    float timer = 0f;

    public Camera shittyVersionOfThisCodeHereHello;
    float defaultTimeBetweenShots = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= 1f * Time.deltaTime;
            if (timer <= 0 && !Input.GetButton("Fire1"))
            {
                StopRecoil();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (timer <= 0)
            {
                StopRecoil();
            }
        }
    }

    public void AddRecoil()
    {

        if (SimpleWeaponHandler.Instance.GetCurrentAmmo() > 0)
        {
            if (maxAimingRecoilAngle != 0)
            {

                if ((360 - maxAimingRecoilAngle) <= transform.localEulerAngles.z || transform.localEulerAngles.z == 0)
                {
                    transform.localEulerAngles += upRecoil / 2;
                }
            }
        }
        else
        {
            if (maxRecoilAngle != 0)
            {

                if ((360 - maxRecoilAngle) <= transform.localEulerAngles.z || transform.localEulerAngles.z == 0)
                {
                    transform.localEulerAngles += upRecoil;
                }
            }
        }


        timer = defaultTimeBetweenShots;
    }


    public void StopRecoil()
    {
        recoilRotation.x = transform.localEulerAngles.x;
        if (ShittyAimCode.isAiming)
        {
            transform.localEulerAngles = originalRotation;
            return;
        }

        Vector3 rotationOutput = Vector3.Slerp(originalRotation, -recoilRotation, recoilDampeningTime * Time.fixedDeltaTime);
        this.transform.localRotation = Quaternion.Euler(rotationOutput);
    }
}
