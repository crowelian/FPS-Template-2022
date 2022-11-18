using TMPro;
using UnityEngine;

public class WeaponUIModule : MonoBehaviour
{

    public TMP_Text weaponAmmoText;

    public void UpdateAmmoText(string ammoCount)
    {
        weaponAmmoText.text = ammoCount;
    }


}
