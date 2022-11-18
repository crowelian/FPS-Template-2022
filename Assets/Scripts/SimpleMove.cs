using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple move made for flying car...
public class SimpleMove : MonoBehaviour
{
    [SerializeField] private Vector3[] targets;
    [SerializeField] private float speed = 1;

    private int currentTarget = 0;

    void Start()
    {
        if (targets.Length == 0)
        {
            targets = new Vector3[] { new Vector3(-55, transform.position.y, -5), new Vector3(0, transform.position.y, 20), new Vector3(55, transform.position.y, 0), transform.position };
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targets[currentTarget]);

        if (distance <= 0.5)
        {
            currentTarget++;
            if (currentTarget >= targets.Length) currentTarget = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, targets[currentTarget], Time.deltaTime * speed);

        Vector3 targetDirection = targets[currentTarget] - transform.position;
        float singleStep = (speed / 4) * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

    }
}
