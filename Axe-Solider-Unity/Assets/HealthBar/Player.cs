using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float healthRegenRate = 1;
    public float regenDelay = 1;
    public float regenHealth;
    private float lastDamagesTime = -1;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        {
            RegenHealth();
        }

        if (lastDamagesTime >= 0 && Time.time - lastDamagesTime >= regenDelay)
        {

        }
    }
    void RegenHealth()
    {
        regenHealth += healthRegenRate * Time.deltaTime;
        int flooredRegenHealth = Mathf.FloorToInt(regenHealth);
        regenHealth -= flooredRegenHealth;
        Heal(flooredRegenHealth);
    }
    void TakeDamage(int damage)
    {
        if(damage < 0)
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        //if(IsDead)
        {
            ///Kill 
        }
    }

    public void Heal(int amount)
    {
        if(amount < 0)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            if (currentHealth == maxHealth)
            {
                lastDamagesTime = -1;
                regenHealth = 0;
                // Full health
            }
        }
    }

}
