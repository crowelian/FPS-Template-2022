using UnityEngine;

public class SimpleRotate : MonoBehaviour
{

    [SerializeField] float xAngle, yAngle, zAngle;

    void Update()
    {
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.Self);
    }
}
