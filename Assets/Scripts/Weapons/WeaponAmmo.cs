using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{

    private Weapon weapon;
    private WeaponUIModule weaponUI = null;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        RefillAmmo();
        if (weaponUI == null)
        {
            weaponUI = GetComponent<WeaponUIModule>();
        }
        weaponUI.UpdateAmmoText(weapon.CurrentAmmo.ToString());
    }

    public void ConsumeAmmo()
    {
        if (weapon.UseMagazine)
        {
            weapon.CurrentAmmo -= 1;
            if (weaponUI != null) weaponUI.UpdateAmmoText(weapon.CurrentAmmo.ToString());
        }
    }

    public void RefillAmmo()
    {
        if (weapon.UseMagazine)
        {
            weapon.CurrentAmmo = weapon.MagazineSize;
            if (weaponUI != null) weaponUI.UpdateAmmoText(weapon.CurrentAmmo.ToString());
        }
       
    }

    public bool CanUseWeapon()
    {
        if (weapon.CurrentAmmo > 0)
        {
            return true;
        }

        return false;
    }

}
