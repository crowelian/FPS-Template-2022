using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


// This code was too specific and not yet refactored... FIX THIS!

public class Computer : MonoBehaviour
{
    public string computerName = "unnamedComputer";
    public string computerOS = "MS-Dos";

    public int powerNeeded = 1;

    [SerializeField]
    private GameObject computerScreen;
    [SerializeField]
    private int computerScreenMaterialIndex;
    [SerializeField]
    private Texture textureToRender;
    [SerializeField]
    private GameObject computerCanvas;
    [SerializeField]
    private Text computerCanvasText;

    private Texture savedTexture;

    private GameObject runningProgram;
    [SerializeField]
    private GameObject computerCamera;
    [SerializeField]
    private GameObject cameraSpawnPosition;
    [SerializeField]
    private Disk insertedDisk;
    [SerializeField]
    private bool programLoaded = false;
    public bool computerInFocus = false;
    [SerializeField]
    private bool thisComputerNeedsCursor = true;

    [SerializeField]
    private AudioSource computerAudio;
    public AudioClip loadAudio;
    public AudioClip writeAudio;
    public AudioClip insertDiskAudio;
    public AudioClip powerOnAudio;
    public AudioClip powerOffAudio;

    public bool useOldColliderSystem = false;

    ///// PowerStation pStation;

    public bool powerOnAtStartup = false;

    [SerializeField]
    public bool computerPowerIsOn = false;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     savedTexture = computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].GetTexture("_EmissionMap");
    //     if (computerCanvasText != null)
    //         computerCanvasText.text = GeneralComputerTexts.IDLE_INSERT_DISK;

    //     if (insertedDisk.programToRun == null)
    //     {
    //         // Debug.Log("SHOW NO PROGRAM SCREEN!");
    //     }

    //     if (computerCamera == null)
    //     {
    //         computerCamera = GameObject.FindGameObjectWithTag("ComputerCamera");
    //     }

    //     pStation = GameObject.FindGameObjectWithTag("MainFrame").GetComponent<SpaceStation>();



    //     if (powerOnAtStartup)
    //     {
    //         computerPowerIsOn = false;
    //         PowerOn();
    //     }
    //     else
    //     {
    //         computerPowerIsOn = true;
    //         PowerOff();
    //     }
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyUp(KeyCode.Escape))
    //     {
    //         computerInFocus = false;
    //         if (computerCamera)
    //         {
    //             if (computerCamera.activeInHierarchy)
    //             {
    //                 DisableComputerCamera();
    //             }
    //         }

    //     }

    //     if (Input.GetKeyUp(KeyCode.L) && computerInFocus)
    //     {
    //         if (insertedDisk.programToRun == null)
    //         {
    //             Debug.Log("ERROR CANNOT LOAD NULL PROGRAM");

    //         }
    //         else
    //         {
    //             if (!programLoaded)
    //             {
    //                 LoadDiskToMemory();
    //             }

    //         }

    //     }


    // }

    // private void OnTriggerStay(Collider other)
    // {

    // }

    // public void LoadDiskToMemory()
    // {

    //     computerCanvasText.text = GeneralComputerTexts.LOADING_DISK;

    //     if (computerAudio != null && loadAudio != null)
    //     {
    //         computerAudio.clip = loadAudio;
    //         computerAudio.Play();
    //     }

    //     if (insertedDisk.programToRun == null)
    //     {
    //         Debug.Log("ERROR: no program on diskette!");
    //         ExitProgam();
    //         return;
    //     }

    //     float loadTime = insertedDisk.programToRun.GetComponent<ProgramOnDisk>().loadTime;

    //     Invoke("LoadProgram", loadTime);
    //     Invoke("StopDiskLoadAudio", loadTime + 3f);
    // }

    // private void StopDiskLoadAudio()
    // {
    //     if (computerAudio.clip == loadAudio)
    //     {
    //         computerAudio.Stop();
    //     }
    // }

    // private void LoadProgram()
    // {


    //     if (computerCanvas != null)
    //     {
    //         computerCanvas.SetActive(false);
    //     }



    //     insertedDisk.programToRun.GetComponent<ProgramOnDisk>().computerRunningThisSoftware = this.gameObject.GetComponent<Computer>();

    //     savedTexture = computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].GetTexture("_EmissionMap");

    //     runningProgram = Instantiate(insertedDisk.programToRun, new Vector3(0, -5000, 0), Quaternion.identity);
    //     runningProgram.transform.parent = this.gameObject.transform;

    //     computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].SetTexture("_EmissionMap", insertedDisk.programToRun.GetComponent<ProgramOnDisk>().renderTexture);

    //     Debug.Log("Program " + insertedDisk.programToRun.GetComponent<ProgramOnDisk>().programName + " Loaded...");
    //     programLoaded = true;
    //     pStation = GameObject.FindGameObjectWithTag("MainFrame").GetComponent<SpaceStation>();
    //     pStation.AddProgramToSpaceStation(runningProgram.GetComponent<ProgramOnDisk>());
    // }

    public void ExitProgam()
    {

        // programLoaded = false;
        // if (computerCanvas != null)
        // {
        //     computerCanvasText.text = GeneralComputerTexts.IDLE_INSERT_DISK;
        //     computerCanvas.SetActive(true);
        // }
        // computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].SetTexture("_EmissionMap", savedTexture);

        // if (runningProgram)
        // {
        //     if (pStation.IsMyProgramOnTheList(runningProgram.GetComponent<ProgramOnDisk>()))
        //     {
        //         pStation = GameObject.FindGameObjectWithTag("MainFrame").GetComponent<SpaceStation>();
        //         pStation.RemoveProgramFromSpaceStation(runningProgram.GetComponent<ProgramOnDisk>());
        //     }

        //     Destroy(runningProgram);
        // }

    }

    // public void UseComputerCamera()
    // {
    //     computerInFocus = true;
    //     // fix this cursor code
    //     if (thisComputerNeedsCursor)
    //     {
    //         Cursor.lockState = CursorLockMode.Confined;
    //         Cursor.visible = true;
    //     }

    //     GameManager.player.SetActive(false);
    //     computerCamera.SetActive(true);
    //     computerCamera.transform.parent = gameObject.transform;

    //     computerCamera.transform.position = cameraSpawnPosition.transform.position;
    //     computerCamera.transform.rotation = cameraSpawnPosition.transform.rotation;
    // }

    // public void DisableComputerCamera()
    // {
    //     computerInFocus = false;
    //     // fix this cursor code
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;

    //     computerCamera.SetActive(false);
    //     GameManager.player.SetActive(true);


    // }

    // public void PowerOn()
    // {
    //     if (!computerPowerIsOn)
    //     {
    //         if (computerCanvas)
    //         {
    //             computerCanvas.SetActive(true);
    //         }

    //         computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].SetTexture("_EmissionMap", savedTexture);
    //        ;
    //         computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].EnableKeyword("_EMISSION");

    //         pStation.AddComputerToSpaceStation(GetComponent<Computer>());
    //         computerPowerIsOn = true;
    //     }
    //     if (computerAudio != null && powerOnAudio != null)
    //     {
    //         computerAudio.clip = powerOnAudio;
    //         computerAudio.Play();
    //     }
    //     if (gameObject.GetComponent<CrosshairTargetRunOnce>()) gameObject.GetComponent<CrosshairTargetRunOnce>().scriptActivated = false;
    // }

    // public void CallPowerOff()
    // {
    //     Invoke("PowerOff", 2f);
    // }

    // public void PowerOff()
    // {
    //     if (computerPowerIsOn)
    //     {
    //         computerPowerIsOn = false;
    //         ExitProgam();
    //         if (computerCanvas)
    //         {
    //             computerCanvas.SetActive(false);
    //         }
    //         if (computerAudio)
    //         {
    //             computerAudio.Stop();
    //         }

    //         computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].SetTexture("_EmissionMap", null);
    //         computerScreen.GetComponent<MeshRenderer>().materials[computerScreenMaterialIndex].DisableKeyword("_EMISSION");
    //         if (ss.IsMyComputerOnTheList(GetComponent<Computer>()))
    //         {
    //             ss.RemoveComputerFromSpaceStation(GetComponent<Computer>());
    //         }

    //         if (this.gameObject.GetComponent<CrosshairTargetRunOnce>())
    //         {
    //             gameObject.GetComponent<CrosshairTargetRunOnce>().scriptActivated = true;
    //         }
    //         if (computerAudio != null && powerOffAudio != null)
    //         {
    //             computerAudio.clip = powerOffAudio;
    //             computerAudio.Play();
    //         }
    //     }


    // }

    // public bool GetComputerPowerIsOn()
    // {
    //     return computerPowerIsOn;
    // }

    // public void PlayerTurnPowerOn()
    // {
    //     if (!computerPowerIsOn)
    //     {
    //         PowerOn();
    //     }
    // }

    // public Disk GetDiskette()
    // {
    //     return insertedDisk;
    // }

    // public void SetDiskette(Disk diskette)
    // {
    //     insertedDisk = diskette;
    // }
}
