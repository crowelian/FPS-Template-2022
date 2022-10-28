using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100;
    public float maxHealth = 100;



    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log(gameObject.name + " dies..,");
            Destroy(gameObject); // Fix this!
        }
    }

    public void Damage(float amount)
    {
        health -= amount;
    }
}
