using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    private void Awake()
    {

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
