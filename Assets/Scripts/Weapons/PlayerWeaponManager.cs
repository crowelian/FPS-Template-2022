using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public static Action OnStartShooting; // event for shooting so other classes can access it

    [Header("Weapon Settings")]
    [SerializeField]
    private Weapon weaponToUse;
    [SerializeField]
    private Transform weaponHolderPosition;

    public bool weaponInUseAtStart = false;


    public Weapon CurrentWeapon;

    public GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        weapons[0] = null;
        if (!weaponInUseAtStart) weapons[1].SetActive(false);
    }

    private void Update()
    {
        HandleInput();
    }


    protected void HandleInput()
    {
        if (Input.GetMouseButton(0))
        {
            if(weapons[1].activeInHierarchy)
            {
               
                Shoot();
            }
            
        }

        if (Input.GetMouseButton(1))
        {
            if (weapons[1].activeInHierarchy)
            {
                Aim();
            } 

        }
        else
        {
            CancelAim();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopWeapon();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            weapons[1].SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            weapons[1].SetActive(true);
        }
    }

    public void Shoot()
    {
        if (CurrentWeapon == null)
        {
            
            return;
        }
        
        CurrentWeapon.TriggerShot();
        //if (character.CharacterType == Character.CharacterTypes.Player)
        //{
            OnStartShooting?.Invoke(); // If on startshooting is not null, invoke it!
                                       //UIManager.Instance.UpdateAmmo(CurrentWeapon.CurrentAmmo, CurrentWeapon.MagazineSize);
                                       //}
    }

    public void Aim()
    {
        
        if (CurrentWeapon == null)
        {

            return;
        }

        if (CurrentWeapon.GetComponent<WeaponAim>())
        {
            CurrentWeapon.GetComponent<WeaponAim>().SetAiming(true);
        }
    }
    public void CancelAim()
    {

        if (CurrentWeapon.GetComponent<WeaponAim>())
        {
            CurrentWeapon.GetComponent<WeaponAim>().SetAiming(false);
        }
    }

    public void StopWeapon()
    {
        if (CurrentWeapon == null)
        {
            return;
        }
        CurrentWeapon.StopWeapon();
    }

    public void Reload()
    {
        if (CurrentWeapon == null)
        {
            return;
        }

        CurrentWeapon.Reload();
        //if (character.CharacterType == Character.CharacterTypes.Player)
        //{
        //    UIManager.Instance.UpdateAmmo(CurrentWeapon.CurrentAmmo, CurrentWeapon.MagazineSize);
        //}
    }

    public void EquipWeapon(Weapon weapon, Transform weaponPosition)
    {
        CurrentWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation);
        CurrentWeapon.transform.parent = weaponPosition;
        //CurrentWeapon.SetOwner(character);
        //WeaponAim = CurrentWeapon.GetComponent<WeaponAim>();


        //if (character.CharacterType == Character.CharacterTypes.Player)
        //{
        //    UIManager.Instance.UpdateAmmo(CurrentWeapon.CurrentAmmo, CurrentWeapon.MagazineSize);
        //}

    }
}
