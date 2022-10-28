using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShittyAimCode : MonoBehaviour
{
    public Camera aimCam;
    public Camera mainCam;
    public GameObject mainCameraObject;
    public GameObject aimCameraObject;
    public GameObject player;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aimCam.enabled = true;
            mainCam.enabled = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            aimCam.enabled = false;
            mainCam.enabled = true;
        }
    }
}
