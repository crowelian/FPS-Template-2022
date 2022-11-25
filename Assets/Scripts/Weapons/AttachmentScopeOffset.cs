using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentScopeOffset : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    void Update()
    {
        if (ShittyAimCode.isAiming && GetComponent<Attachment>().attachmentModel.activeInHierarchy) // fix this, just baaad
        {
            GetComponent<Attachment>().attachmentWeapon.GetComponent<WeaponAim>().offset = offset;
            CrosshairManager.Instance.SetCrosshairVisibility(false);
        }
        else
        {
            UnsetAll();
        }
    }

    private void OnDisable()
    {
        UnsetAll();
    }

    private void OnDestroy()
    {
        UnsetAll();
    }

    void UnsetAll()
    {
        if (GetComponent<Attachment>().attachmentModel.activeInHierarchy)
        {
            GetComponent<Attachment>().attachmentWeapon.GetComponent<WeaponAim>().offset = Vector3.zero;
            CrosshairManager.Instance.SetCrosshairVisibility(true);
            CrosshairManager.Instance.SetDefault();
        }
    }

}
