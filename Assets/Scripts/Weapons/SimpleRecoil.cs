using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{


    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;
    [SerializeField] float aimingDeMultiplier = 0.1f;
    [SerializeField] float snap;
    [SerializeField] float recoilDampeningTime = 11f;
    Vector3 currentRotation;
    Vector3 recoilRotation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (recoilRotation != Vector3.zero)
        {
            recoilRotation = Vector3.Lerp(recoilRotation, Vector3.zero, recoilDampeningTime * Time.deltaTime);
            currentRotation = Vector3.Slerp(currentRotation, recoilRotation, snap * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(currentRotation);
        }

    }

    public void AddRecoil()
    {

        if (ShittyAimCode.isAiming)
        {
            recoilRotation += new Vector3(recoilX * aimingDeMultiplier, Random.Range(-recoilY * aimingDeMultiplier, recoilY * aimingDeMultiplier), Random.Range(-recoilZ * aimingDeMultiplier, recoilZ * aimingDeMultiplier));
        }
        else
        {
            recoilRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        }


    }



}
