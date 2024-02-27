
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int speed;
    public float lifeTime = 5.0f;
    public float damage;

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
