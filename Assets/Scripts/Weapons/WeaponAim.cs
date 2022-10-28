using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField]
    private Transform weaponHolder;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform aimPoint;

    [SerializeField]
    private bool aiming = false;

   

    public void SetAiming(bool setAiming)
    {
        aiming = setAiming;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        CancelAim();
    }

    public void Aim()
    {
        if (aiming) weaponHolder.transform.position = aimPoint.transform.position;
    }

    public void CancelAim()
    {
        if (!aiming) weaponHolder.transform.position = startPoint.transform.position;
    }
}
