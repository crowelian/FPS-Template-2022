using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIModule : MonoBehaviour
{

    public Text weaponAmmoText;

   public void UpdateAmmoText(string ammoCount)
    {
        weaponAmmoText.text = ammoCount;
    }


}
