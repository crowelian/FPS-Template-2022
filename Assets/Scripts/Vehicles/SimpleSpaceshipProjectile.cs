using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpaceshipProjectile : MonoBehaviour
{

    [SerializeField] GameObject explosionEffect;

    float speed = 10f;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ship")
        {
            Debug.Log("Collision on Shot " + col.gameObject.name);
            SimpleSpaceshipController spaceship = col.gameObject.GetComponent<SimpleSpaceshipController>();
            spaceship.ApplyDamage();
            DoExplode();
            Destroy(gameObject);
        }
        else
        {
            DoExplode();
            Destroy(gameObject);
        }

    }

    void DoExplode()
    {
        if (explosionEffect)
        {
            GameObject thisExplosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(thisExplosion, 2);
        }

    }

    private void LateUpdate()
    {
        // transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
