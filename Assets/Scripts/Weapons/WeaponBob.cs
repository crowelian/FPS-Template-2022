using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBob : MonoBehaviour
{
    [SerializeField] float weaponBobbingSpeed = 14f;
    [SerializeField] float bobbingAmount = 0.05f;

    float defaultPosY = 0;
    float timer = 0;

    public bool isBobbingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstPersonController.isWalking && !ShittyAimCode.isAiming)
        {
            isBobbingAway = true;
            timer += Time.deltaTime * weaponBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            isBobbingAway = false;
        }

    }
}
