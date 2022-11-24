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
    public Vector3 offset; // TODO FIX THIS

    [SerializeField]
    private bool aiming = false;

    private float _current, _target;
    private float _speed = 4f;


    [SerializeField] AnimationCurve _curve;

    public void SetOffset()
    {
        weaponHolder.transform.position += offset;
    }

    public void SetAiming(bool setAiming)
    {
        aiming = setAiming;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        CancelAim();
        AimAnimation();
        SetOffset();
    }

    public void Aim()
    {
        if (aiming)
        {
            _target = 1;
        }

    }

    public void CancelAim()
    {
        if (!aiming)
        {
            _target = 0;
        }
    }

    void AimAnimation()
    {
        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);

        weaponHolder.transform.position = Vector3.Lerp(startPoint.transform.position, aimPoint.transform.position, _curve.Evaluate(_current));
        // No rotation now... TODO: if going to use fix weapon sway and this...
        //weaponHolder.transform.rotation = Quaternion.Lerp(Quaternion.Euler(startPoint.transform.rotation.eulerAngles), Quaternion.Euler(aimPoint.transform.rotation.eulerAngles), _curve.Evaluate(_current));
    }
}
