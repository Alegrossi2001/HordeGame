using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    EnemyClass basicZombie = new EnemyClass();
    private Transform target;
    public float health;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        health = basicZombie.life;
    }
    // Update is called once per frame
    void Update()
    {
        var step = basicZombie.speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamageHealth(float damage)
    {
        health-= damage;
    }
}
