using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public override void takeHit(float damage)
    {
        base.takeHit(damage);
    }

    public override void heal(float amount)
    {
        base.heal(amount);
    }

    public override void die()
    {
        base.die();
    }
}
