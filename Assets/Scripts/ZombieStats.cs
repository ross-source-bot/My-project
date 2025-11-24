using System.IO;
using UnityEngine;

public class ZombieStats : CharacterStats
{
    [SerializeField] public int damage;
    public bool isZombie;
    public float attackSpeed;
    public float health = 10f; //
    [SerializeField] private bool canAttack;

    private void Start()
    {
        InitVariables();
        health = maxHealth;
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    public void TakeDamage (int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
            isDead = true;
        }
    }


    public override void Die() ///
    {
        //base.Die();
        if (isZombie)
        {
            health = maxHealth;
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("Zombie Dead");
    }

    public override void InitVariables()
    {
        maxHealth = 10;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1f;
        canAttack = true;
    }
}
