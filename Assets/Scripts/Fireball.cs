using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int speed;
    public float lifeTime;
    public float damage;
    public EnemyHealth health;

    private void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
        DestroyFireball();
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
