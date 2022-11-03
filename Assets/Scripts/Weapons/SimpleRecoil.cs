using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{
    [SerializeField] Vector3 upRecoil;
    [SerializeField] float maxRecoilAngle;
    [SerializeField] float maxAimingRecoilAngle;
    Vector3 originalRotation;
    float timer = 0f;

    public Camera shittyVersionOfThisCodeHereHello;
    public bool doThisCheckBetterPlease = false;
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

        if (Input.GetButtonDown("Fire1"))
        {
            doThisCheckBetterPlease = true;
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

        if (shittyVersionOfThisCodeHereHello.enabled)
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
        doThisCheckBetterPlease = false;
        transform.localEulerAngles = originalRotation;
    }
}
