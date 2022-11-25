using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public static PlayerWeaponManager Instance;

    public static Action OnStartShooting; // event for shooting so other classes can access it

    [Header("Weapon Settings")]
    [SerializeField]
    private Weapon weaponToUse;
    [SerializeField]
    private Transform weaponHolderPosition;

    public bool weaponInUseAtStart = false;


    public Weapon CurrentWeapon;

    public GameObject[] weapons;


    // TODO fix this
    public AudioSource shoot;
    [SerializeField] GameObject hitDebris;

    WeaponAim weaponAim;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] Transform weaponShootDirection;
    // End of fix these

    // Start is called before the first frame update
    void Start()
    {
        weapons[0] = null;
        if (!weaponInUseAtStart) weapons[1].SetActive(false);

        weaponAim = this.GetComponent<WeaponAim>();

    }

    private void Update()
    {
        HandleInput();



    }





    protected void HandleInput()
    {

        // TODO FIX THIS:
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<SimpleWeaponHandler>().GetCurrentAmmo() <= 0)
            {
                // TODO: play empty clip sound here!
                return;
            }

            AudioManager.PlayAudioIfNotPlaying(shoot, true);
            if (CurrentWeapon != null)
            {
                CurrentWeapon.GetComponent<SimpleRecoil>().AddRecoil();
            }
            ProcessWeaponHit();
            GetComponent<SimpleWeaponHandler>().RemoveAmmo(1);

        }
        // END OF FIX THIS

        if (Input.GetMouseButton(1))
        {
            Aim();
        }
        else
        {
            CancelAim();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reload");
        }




        if (Input.GetMouseButton(0))
        {
            if (weapons[1].activeInHierarchy)
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


    // TODO Fix this
    void ProcessWeaponHit()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(weaponShootDirection.position, weaponShootDirection.forward, out hitInfo, 300))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            GameObject hitDebris1 = Instantiate(hitDebris, hitInfo.point, Quaternion.identity);
            Material newHitMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            newHitMat.color = new Color(1, 1, 1, 1);
            hitDebris1.GetComponent<MeshRenderer>().material = newHitMat;
            if (hitObject.GetComponent<MeshRenderer>())
            {
                string findTexture = "_BaseMap";
                Texture2D materialTexture2d = hitObject.GetComponent<MeshRenderer>().sharedMaterial.GetTexture(findTexture) as Texture2D;
                if (materialTexture2d && materialTexture2d.isReadable)
                {
                    hitDebris1.GetComponent<MeshRenderer>().sharedMaterial.color = materialTexture2d.GetPixel((int)hitInfo.textureCoord.x, (int)hitInfo.textureCoord.y);
                }
                else
                {
                    hitDebris1.GetComponent<MeshRenderer>().sharedMaterial.color = hitObject.GetComponent<MeshRenderer>().sharedMaterial.color;
                }
            }
            else if (hitObject.GetComponent<HitColor>())
            {
                hitDebris1.GetComponent<MeshRenderer>().sharedMaterial.color = hitObject.GetComponent<HitColor>().hitColor;
            }


            // TODO: check if health component is present etc...

        }
    }
}
