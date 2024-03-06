using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    public float healAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.health += healAmount;
            player.health = Mathf.Clamp(player.health, 0, player.maxHealth);
            player.DrawHealthBar();
            Destroy(gameObject);
        }
    }
}
