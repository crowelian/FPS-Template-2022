using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    [SerializeField] float speed = 0.1f;
    float Xsensitivity = 4f;
    float Ysensitivity = 4f;
    float MinimumX = -90f;
    float MaximumX = 90;
    Rigidbody rb;
    CapsuleCollider capsule;
    bool isWalking;

    WeaponAim weaponAim;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] Transform weaponShootDirection;
    [SerializeField] GameObject hitDebris;
    [SerializeField] GameObject cam;
    Quaternion cameraRotation;
    Quaternion characterRotation;
    bool cursorIsLocked = true;
    bool lockCursor = true;

    float x;
    float z;

    // Audio
    public AudioSource[] footsteps;
    public AudioSource jump;
    public AudioSource land;
    public AudioSource shoot;
    public AudioSource healthPickup;
    public AudioSource ammoPickup;


    void Awake()
    {
        cameraRotation = cam.transform.localRotation;
        characterRotation = this.transform.localRotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        capsule = this.GetComponent<CapsuleCollider>();
        weaponAim = this.GetComponent<WeaponAim>();

        cursorIsLocked = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<SimpleWeaponHandler>().GetCurrentAmmo() <= 0)
            {
                // TODO: play empty clip sound here!
                return;
            }

            PlayAudioIfNotPlaying(shoot, true);
            if (currentWeapon != null)
            {
                currentWeapon.GetComponent<SimpleRecoil>().AddRecoil();
            }
            ProcessWeaponHit();
            GetComponent<SimpleWeaponHandler>().RemoveAmmo(1);

        }

        if (Input.GetMouseButton(1))
        {
            weaponAim.SetAiming(true);
        }
        else
        {
            weaponAim.SetAiming(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reload");
        }


        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)
        {
            if (isWalking == false)
            {
                if (IsGrounded())
                {
                    isWalking = true;
                    InvokeRepeating("PlayFootStepAudio", 0, 0.3f);
                }
                else
                {
                    isWalking = false;
                    CancelInvoke("PlayFootStepAudio");
                }


            }


        }
        else
        {
            isWalking = false;
            CancelInvoke("PlayFootStepAudio");
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(0, 300, 0);
            PlayAudioIfNotPlaying(jump);
        }

    }

    void FixedUpdate()
    {
        float yRot = Input.GetAxis("Mouse X") * Xsensitivity;
        float xRot = Input.GetAxis("Mouse Y") * Ysensitivity;

        cameraRotation *= Quaternion.Euler(-xRot, 0, 0);
        characterRotation *= Quaternion.Euler(0, yRot, 0);

        cameraRotation = ClampRotationAroundXAxis(cameraRotation);

        this.transform.localRotation = characterRotation;
        cam.transform.localRotation = cameraRotation;

        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;


        transform.position += cam.transform.forward * z + cam.transform.right * x; //new Vector3(x * speed, 0, z * speed);

        UpdateCursorLock();
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

    bool IsGrounded()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, capsule.radius, Vector3.down, out hitInfo,
                (capsule.height / 2f) - capsule.radius + 0.1f))
        {
            return true;
        }
        return false;
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        if (lockCursor)
            InternalLockUpdate();
    }

    public void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorIsLocked = true;
        }


        if (cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void PlayFootStepAudio()
    {
        AudioSource audioSource = new AudioSource();
        int n = Random.Range(1, footsteps.Length);

        audioSource = footsteps[n];
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        footsteps[n] = footsteps[0];
        footsteps[0] = audioSource;
    }

    void OnCollisionEnter(Collision col)
    {
        // TODO add different ground types etc...
        if (IsGrounded())
        {
            if (!land.isPlaying)
            {
                if (!isWalking)
                {
                    PlayAudioIfNotPlaying(land);
                }

            }

        }

        CheckPickup<Collision>(col);

    }

    void OnTriggerEnter(Collider other)
    {
        CheckPickup<Collider>(other);
    }

    void CheckPickup<T>(T col)
    {

        // TODO: FIX ALL OF THIS Horrendous stuff!
        if (col is Collision || col is Collider)
        {
            if (col is Collider)
            {
                Collider collision = col as Collider;
                if (collision.gameObject.tag == "Health")
                {
                    Debug.Log("Health Pickup");
                    Destroy(collision.gameObject);
                    GetComponent<Health>().Heal(25f);
                    PlayAudioIfNotPlaying(healthPickup);
                }

                else if (collision.gameObject.tag == "Ammo")
                {
                    Debug.Log("Ammo Pickup");
                    Destroy(collision.gameObject);
                    GetComponent<SimpleWeaponHandler>().AddAmmo(50);
                    PlayAudioIfNotPlaying(ammoPickup);
                }
            }
            if (col is Collision)
            {
                Collision collision = col as Collision;
                if (collision.gameObject.tag == "Health")
                {
                    Debug.Log("Health Pickup");
                    Destroy(collision.gameObject);
                    GetComponent<Health>().Heal(25f);
                    PlayAudioIfNotPlaying(healthPickup);
                }

                else if (collision.gameObject.tag == "Ammo")
                {
                    Debug.Log("Ammo Pickup");
                    Destroy(collision.gameObject);
                    GetComponent<SimpleWeaponHandler>().AddAmmo(50);
                    PlayAudioIfNotPlaying(ammoPickup);
                }

            }



        }


    }


    void PlayAudioIfNotPlaying(AudioSource playThis, bool noWait = false)
    {
        if (playThis == null)
        {
            return;
        }
        if (playThis.isPlaying && noWait == false)
        {
            return;
        }

        playThis.Play();
    }


    void ProcessWeaponHit()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(weaponShootDirection.position, weaponShootDirection.forward, out hitInfo, 300))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            GameObject hitDebris1 = Instantiate(hitDebris, hitInfo.point, Quaternion.identity);
            Material newHitMat = new Material(Shader.Find("Standard"));
            newHitMat.color = new Color(1, 1, 1, 1);
            hitDebris1.GetComponent<MeshRenderer>().material = newHitMat;
            if (hitObject.GetComponent<MeshRenderer>())
            {
                hitDebris1.GetComponent<MeshRenderer>().sharedMaterial.color = hitObject.GetComponent<MeshRenderer>().sharedMaterial.color;
            }
            else if (hitObject.GetComponent<HitColor>())
            {
                hitDebris1.GetComponent<MeshRenderer>().sharedMaterial.color = hitObject.GetComponent<HitColor>().hitColor;
            }


            // TODO: check if health component is present etc...

        }
    }


}
