using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    public static FirstPersonController Instance;
    [SerializeField] float speed = 0.1f;

    Rigidbody rb;
    public CapsuleCollider capsule;
    public static bool isWalking;
    public static bool isRunning;

    float runningMultiplier = 1.7f;

    public bool canControlPlayer = true; // TODO Fix this


    [SerializeField] GameObject cam;

    Quaternion characterRotation;


    float x;
    float z;

    // Audio
    public AudioSource[] footsteps;
    public AudioSource jump;
    public AudioSource land;

    public AudioSource healthPickup;
    public AudioSource ammoPickup;


    public GameObject playerGear; // easier to enable / disable all weapons, helmet, shield etc...


    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;
        characterRotation = this.transform.localRotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        capsule = this.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canControlPlayer)
        {
            if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)
            {
                if (isWalking == false)
                {
                    if (IsGrounded())
                    {
                        isWalking = true;
                        if (isRunning)
                        {
                            InvokeRepeating("PlayFootStepAudio", 0, 0.1f);
                        }
                        else
                        {
                            InvokeRepeating("PlayFootStepAudio", 0, 0.3f);
                        }

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
                AudioManager.PlayAudioIfNotPlaying(jump);
            }



        }


    }

    void FixedUpdate()
    {
        if (canControlPlayer)
        {
            x = Input.GetAxis("Horizontal") * speed;
            z = Input.GetAxis("Vertical") * speed;

            IsRunning();

            if (isRunning)
            {
                x = x * (runningMultiplier * 0.8f);
                z = z * runningMultiplier;
            }


            transform.position += cam.transform.forward * z + cam.transform.right * x; //new Vector3(x * speed, 0, z * speed);
        }

    }

    void IsRunning()
    {
        if (Input.GetKey(InputManager.Instance.run))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
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
                    AudioManager.PlayAudioIfNotPlaying(land);
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
                    AudioManager.PlayAudioIfNotPlaying(healthPickup);
                }

                else if (collision.gameObject.tag == "Ammo")
                {
                    Debug.Log("Ammo Pickup");
                    Destroy(collision.gameObject);
                    GetComponent<SimpleWeaponHandler>().AddAmmo(50);
                    AudioManager.PlayAudioIfNotPlaying(ammoPickup);
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
                    AudioManager.PlayAudioIfNotPlaying(healthPickup);
                }

                else if (collision.gameObject.tag == "Ammo")
                {
                    Debug.Log("Ammo Pickup");
                    Destroy(collision.gameObject);
                    GetComponent<SimpleWeaponHandler>().AddAmmo(50);
                    AudioManager.PlayAudioIfNotPlaying(ammoPickup);
                }

            }



        }


    }








}
