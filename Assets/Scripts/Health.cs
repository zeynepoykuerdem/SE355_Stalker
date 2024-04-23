using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour,IHittable
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;

    public virtual void takeHit(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            die();
        }
    }

    public virtual void die()
    {

    }

    public virtual void heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
}
