using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpaceshipController : MonoBehaviour
{
    public static SimpleSpaceshipController Instance;


    private GameObject thisPlayer;
    [SerializeField] GameObject healthBar;
    private float health;
    public Camera playerCamera;
    [SerializeField] GameObject gun1;
    [SerializeField] GameObject gun2;
    private float shotTimer;
    [SerializeField] GameObject m_shotPrefab;
    [SerializeField] GameObject explosionEffect;
    private float speed;
    private float drag = 0.3f;

    float cooldDown = 0f;

    public bool playerCanControl = false;



    public AudioSource shoot;


    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;
    }

    void Start()
    {
        thisPlayer = gameObject;
        shotTimer = 0;
        health = 0.3f;
        healthBar.transform.localScale = new Vector3(0.1f, health, 0.1f);
        if (playerCanControl)
        {
            playerCamera.enabled = true;
        }
        else
        {
            playerCamera.enabled = false;
        }
    }


    void Update()
    {
        if (playerCanControl)
        {
            float roll = 0;
            if (Input.GetKey(InputManager.Instance.spaceShipRollLeft))
            {
                roll = -1;
            }
            if (Input.GetKey(InputManager.Instance.spaceShipRollRight))
            {
                roll = 1;
            }
            transform.Rotate(new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), -roll) * Time.deltaTime * 30);
            float acc = Input.GetKey(InputManager.Instance.spaceShipThruster) ? 1 : 0 * 5;
            speed += acc * Time.deltaTime;
            if (speed > 10)
            {
                speed = 10;
            }
            if (speed > 0)
            {
                speed -= drag * Time.deltaTime;
            }
            // Fire guns script
            float fire = Input.GetAxis("Fire1");
            if (fire > 0 && shotTimer < 0)
            {
                FireShot(gun1.transform.position, gun1.transform.forward);
                FireShot(gun2.transform.position, gun2.transform.forward);
                shotTimer = 15;
                AudioManager.PlayAudioIfNotPlaying(shoot);
            }
            shotTimer -= Time.deltaTime * 30;
        }
    }

    private void OnDisable()
    {
        playerCanControl = false;
    }

    private void OnDestroy()
    {
        playerCanControl = false;
    }


    void FireShot(Vector3 gunpos, Vector3 gundir)
    {
        GameObject thisShot = Instantiate(m_shotPrefab, gunpos, m_shotPrefab.transform.rotation);
        Rigidbody rb = thisShot.GetComponent<Rigidbody>();
        rb.velocity = gundir * 100;
        Destroy(thisShot, 5);
    }
    private void FixedUpdate()
    {
        if (playerCanControl)
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
        }
    }

    public void ApplyDamage()
    {
        health -= 0.01f;
        if (health < 0)
        {
            // Player is destroyed
            Destroy(thisPlayer);
        }
        Debug.Log("Damage Applied " + thisPlayer.gameObject.GetInstanceID().ToString());
        if (healthBar) healthBar.transform.localScale = new Vector3(0.1f, health, 0.1f);
        if (explosionEffect)
        {
            GameObject thisExplosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(thisExplosion, 2);
        }

    }

}
