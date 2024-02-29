
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
        if (other.transform.root.TryGetComponent(out EnemyHealth enemyHealth))
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
