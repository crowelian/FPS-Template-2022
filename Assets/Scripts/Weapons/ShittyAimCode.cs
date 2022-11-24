using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShittyAimCode : MonoBehaviour
{
    [SerializeField] Camera _aimCam;
    [SerializeField] Camera _mainCam;

    public static Camera aimCam;
    public static Camera mainCam;
    public GameObject mainCameraObject;
    public GameObject aimCameraObject;
    public GameObject player;

    public static bool isAiming;

    [SerializeField] WeaponAim weaponAim;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (_aimCam != null && _mainCam != null)
        {
            aimCam = _aimCam;
            mainCam = _mainCam;
        }
        if (weaponAim == null)
        {
            weaponAim = GetComponent<WeaponAim>();
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isAiming)
            {
                if (CrosshairManager.Instance) CrosshairManager.Instance.SetAim();
            }

            isAiming = true;

            if (weaponAim)
            {
                weaponAim.SetAiming(isAiming);
            }
            else
            {
                // TODO fix this with position transition
                aimCam.enabled = true;
                mainCam.enabled = false;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (isAiming)
            {
                if (CrosshairManager.Instance) CrosshairManager.Instance.SetDefault();
            }

            isAiming = false;

            if (weaponAim)
            {
                weaponAim.SetAiming(isAiming);
            }
            else
            {
                // TODO fix this with position transition
                aimCam.enabled = false;
                mainCam.enabled = true;
            }
        }
    }
}
