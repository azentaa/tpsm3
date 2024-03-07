using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _maxSize = 5;
    public float speed;
    public float damage = 30;
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.y > _maxSize)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.health -= damage;
            player.DrawHealthBar();
        }
        if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.enemyHealthValue -= damage;
        }
    }
}
