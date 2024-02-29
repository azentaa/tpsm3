using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    private float _maxHealth;
    

    private void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(health/_maxHealth,1);
    }

    private void Dead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
