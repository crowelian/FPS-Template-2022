using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    public static SettingsManager Instance;

    [SerializeField] float mouseSensitivityX = 3f;
    [SerializeField] float mouseSensitivityY = 3f;
    public float mouseLookSpeed = 4f;

    void Awake()
    {
        Debug.Log("Awake initialization");
        if (Instance != null) { Destroy(this); }
        else Instance = this;
        Debug.Log("Awake initialization over");
    }


    public void SetMouseSensitivity(float x, float y)
    {
        mouseSensitivityX = x;
        mouseSensitivityY = y;
    }
    public float[] GetMouseSensitivityXY()
    {
        float[] mouseSensitivity = { mouseSensitivityX, mouseSensitivityY };
        return mouseSensitivity;
    }

    public float GetMouseSensitivityX()
    {
        return mouseSensitivityX;
    }

    public float GetMouseSensitivityY()
    {
        return mouseSensitivityY;
    }


}
