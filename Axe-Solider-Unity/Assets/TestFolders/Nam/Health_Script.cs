using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Script : MonoBehaviour
{
    private int health;
    private int healthMax;

    public Health_Script(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageValue)
    {
        health -= damageValue;
        if (health < 0) health = 0;
    }
    public void Heal(int healValue)
    {
        health += healValue;
        if (health > healthMax) health = healthMax;
    }
}
