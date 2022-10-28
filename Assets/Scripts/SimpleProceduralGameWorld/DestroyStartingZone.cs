using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartingZone : MonoBehaviour
{
    
    void Start()
    {
        // This needs to be destroyed at the moment
        // because otherwise the sensor ai cannot enter this zone...
        Destroy(gameObject, 2f);
    }

    
}
