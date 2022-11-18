using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeaponHandler : MonoBehaviour
{

    public static SimpleWeaponHandler Instance;

    [SerializeField] GameObject currentWeapon;
    [SerializeField] int currentAmmo = 50;
    [SerializeField] int maxAmmo = 255;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = new SimpleWeaponHandler();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }



    public void RemoveAmmo(int amount)
    {
        currentAmmo -= amount;
    }
    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
}
