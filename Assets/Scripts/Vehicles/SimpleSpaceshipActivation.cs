using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpaceshipActivation : MonoBehaviour
{
    public void Activate()
    {
        SimpleSpaceshipController.Instance.playerCanControl = true;
        SimpleSpaceshipController.Instance.ActivateShip();
    }
}
