using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass
{
    public float speed;
    public float damage;
    public float life;
    public float knockbackRes;

    public EnemyClass()
    {
        speed = 4.0f;
        damage = 1.0f;
        life = 20.0f;
        knockbackRes = 1.0f;
    }
    public EnemyClass(float newSpeed, float newDamage, float newlife, float newknockbackRes)
    {
        speed = newSpeed;
        damage = newDamage;
        life = newlife;
        knockbackRes= newknockbackRes;
    }

}
