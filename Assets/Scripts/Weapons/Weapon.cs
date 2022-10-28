﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    public float timeBetweenShots = 0.5f;

    [Header("Weapon")]
    [SerializeField]
    private bool useMagazine = true;
    [SerializeField]
    private int magazineSize = 30;
    [SerializeField]
    private bool autoReload = true;

    [Header("Recoil")]
    [SerializeField]
    private bool useRecoil = true;
    [SerializeField]
    private int recoilForce = 5;

    [Header("Effects")]
    [SerializeField]
    private ParticleSystem muzzleFlash;

    //public Character WeaponOwner { get; set; }
    [SerializeField]
    public int CurrentAmmo { get; set; }

    public WeaponAmmo WeaponAmmo { get; set; }

    public bool UseMagazine => useMagazine;

    public int MagazineSize => magazineSize;

    public bool CanShoot { get; set; }

    private float nextShotTime;

    [SerializeField]
    private Animator animator;

    private readonly int weaponUseParameter = Animator.StringToHash("WeaponUse");


    protected virtual void Awake()
    {
        WeaponAmmo = GetComponent<WeaponAmmo>();
        
        CurrentAmmo = magazineSize;
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected virtual void Update()
    {
        WeaponCanShoot();
        //RotateWeapon();
    }

    public void TriggerShot()
    {
        
        StartShooting();
    }

    public void StopWeapon()
    {
        //if (useRecoil)
        //{
        //    controller.ApplyRecoil(Vector2.one, 0f);
        //}
    }

    private void StartShooting()
    {
        if (useMagazine)
        {
            if (WeaponAmmo != null)
            {
                if (WeaponAmmo.CanUseWeapon())
                {
                    RequestShot();
                }
                else
                {
                    if (autoReload)
                    {
                        Reload();
                    }
                    else
                    {
                        if (gameObject.GetComponent<WeaponAudioModule>())
                        {
                            gameObject.GetComponent<WeaponAudioModule>().PlayEmptyMagazineAudio();
                        }
                    }
                }
            }
        }
        else
        {
            RequestShot();
        }
    }

    protected virtual void RequestShot()
    {
        if (!CanShoot)
        {
            
            return;
        }

        if (useRecoil)
        {
            Recoil();
        }

        if (animator != null)
        {
            animator.SetTrigger(weaponUseParameter);
        }
        WeaponAmmo.ConsumeAmmo();
        if (muzzleFlash) muzzleFlash.Play();
    }

    private void Recoil()
    {
        if (GetComponent<SimpleRecoil>())
        {
            GetComponent<SimpleRecoil>().AddRecoil();
        }
        //if (WeaponOwner != null)
        //{
        //    if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        //    {
        //        controller.ApplyRecoil(Vector2.left, recoilForce);
        //    }
        //    else
        //    {
        //        controller.ApplyRecoil(Vector2.right, recoilForce);
        //    }
        //}
    }

    protected virtual void WeaponCanShoot()
    {
        if (Time.time > nextShotTime)
        {
            CanShoot = true;
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    //public void SetOwner(Character owner)
    //{
    //    WeaponOwner = owner;
    //    controller = WeaponOwner.GetComponent<CharacterController2D>();
    //}

    public void Reload()
    {
        if (WeaponAmmo != null)
        {
            if (useMagazine)
            {
                WeaponAmmo.RefillAmmo();
            }
            if (gameObject.GetComponent<WeaponAudioModule>())
            {
                gameObject.GetComponent<WeaponAudioModule>().PlayReloadAudio();
            }
        }

    }

    protected virtual void RotateWeapon()
    {
        //if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
    }




}