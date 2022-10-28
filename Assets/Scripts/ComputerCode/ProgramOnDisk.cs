using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramOnDisk : MonoBehaviour
{
    public string programName = "unnamed program";
    public Computer computerRunningThisSoftware = null;
    private string runningThisWith = "";
    public Text uiComputerInfo;

    //This is like the "game manager" kinda...
    public int powerNeeded = 1;
    public float loadTime = 8f;
    public Texture renderTexture;

    public GameObject screen01;
    public GameObject screen02;

    public Canvas canvas;
    public Button button01;
    public Button button02;
    public Button button03;

    public bool uiIsActive = false;
    public bool isTestDemoProgram = false;
    public bool runInDebugMode = false;

    public Computer GetComputerRunningThisProgram() => computerRunningThisSoftware;


    // Start is called before the first frame update
    void Start()
    {
        if (computerRunningThisSoftware != null)
        {
            runningThisWith = computerRunningThisSoftware.computerName + " - " + computerRunningThisSoftware.computerOS;
            if (uiComputerInfo != null)
            {
                uiComputerInfo.text = runningThisWith;
            }
        }

        screen02.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (computerRunningThisSoftware.computerInFocus || runInDebugMode)
        {


            if (isTestDemoProgram)
            {
                if (Input.GetKeyUp(KeyCode.DownArrow) && !uiIsActive && !screen02.activeInHierarchy)
                {
                    uiIsActive = true;
                    // Select the button
                    button01.Select();

                    button01.OnSelect(null);

                }
                if (Input.GetKeyUp(KeyCode.UpArrow) && !uiIsActive && !screen02.activeInHierarchy)
                {
                    uiIsActive = true;
                    // Select the button
                    button02.Select();

                    button02.OnSelect(null);

                }
                if (screen02.activeInHierarchy)
                {
                    if (button01 != null) button01.OnDeselect(null);
                    if (button02 != null) button02.OnDeselect(null);
                    if (Input.GetKeyUp(KeyCode.Z))
                    {
                        ProgramShowScreen01();
                    }
                }
            }

            //if (screen02.activeInHierarchy && (Input.GetKeyUp(KeyCode.DownArrow)))
            //{
            //    //uiIsActive = true;
            //    // Select the button
            //    button03.Select();

            //    button03.OnSelect(null);
            //}
        }
        else
        {
            if (button01 != null) button01.OnDeselect(null);
            if (button02 != null) button02.OnDeselect(null);
            //button03.OnDeselect(null);
        }



    }

    public void ProgramActivity01()
    {
        Debug.Log("prog1");
    }

    public void ProgramActivity02()
    {
        Debug.Log("prog2");
    }

    public void ProgramExit()
    {
        computerRunningThisSoftware.ExitProgam();
    }

    public void ProgramShowScreen01()
    {
        if (screen01 != null) screen01.SetActive(true);
        if (screen02 != null) screen02.SetActive(false);
        uiIsActive = false;
    }

    public void ProgramShowScreen02()
    {
        if (screen02 != null) screen02.SetActive(true);
        if (screen01 != null) screen01.SetActive(false);

    }
}
