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
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aimCam.enabled = true;
            mainCam.enabled = false;
            isAiming = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            aimCam.enabled = false;
            mainCam.enabled = true;
            isAiming = false;
        }
    }
}
