using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    abstract public void TakeDamage(float damage,DamageType damageType=null);
   
}
