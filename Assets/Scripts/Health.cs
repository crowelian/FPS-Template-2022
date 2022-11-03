using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100;
    [SerializeField] float maxHealth = 100;



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
    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public float GetCurrentHealt()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
