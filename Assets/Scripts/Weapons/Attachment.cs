using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachment : MonoBehaviour
{

    public string attachmentName = "Attachment";
    public Weapon attachmentWeapon;
    public GameObject attachmentModel; // Fix this!

    void Start()
    {
        if (attachmentWeapon == null)
        {

            // go through parent obects until you find canvas!
            Transform testIfIamWeapon = transform.parent;
            while (testIfIamWeapon != null)
            {
                attachmentWeapon = testIfIamWeapon.GetComponent<Weapon>();
                if (attachmentWeapon != null)
                {
                    break;
                }
                testIfIamWeapon = testIfIamWeapon.parent;
            }



        }
    }

}
