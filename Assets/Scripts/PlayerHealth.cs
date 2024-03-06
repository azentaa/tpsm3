using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public float maxHealth;
    

    private void Start()
    {
        maxHealth = health;
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

    public void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(health/maxHealth,1);
    }

    private void Dead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
}
