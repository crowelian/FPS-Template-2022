using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfStartingZone : MonoBehaviour
{

    [SerializeField]
    private string startingZoneTag = "StartingZone";
    [SerializeField]
    private bool allowToBeCreatedInsideStartingZone = false;


    void OnTriggerStay(Collider other)
    {
        
            if (other.gameObject.tag == startingZoneTag)
            {
                Destroy(gameObject);
            }
        
        
    }
}
