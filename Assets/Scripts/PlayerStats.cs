using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
    }

    public override void CheckHealth()
    {
        hud.UpdateHealth(health, maxHealth);
        if (health <= 0)
        {
            isDead = true;
            gameManager.GameOver();
            Debug.Log("Dead");
            
            Cursor.lockState = CursorLockMode.None; 
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(50);
        }
    }
}

