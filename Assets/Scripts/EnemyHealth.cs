using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public float enemyHealthValue = 100;

    public void DealDamage(float damage)
    {
        enemyHealthValue -= damage;
        if (enemyHealthValue <= 0) Destroy(gameObject);
    }
}
