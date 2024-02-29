using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;
    private float _maxHealth;

    private void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(health/_maxHealth,1);
    }
}
