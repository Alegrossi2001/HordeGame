using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float shootingDistance = 7f;
    [SerializeField] float speedArrow = 5f;
    [SerializeField] float fireRate = 3f;
    public GameObject arrow;
    GameObject target;
    bool canShoot = true;

    void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            //Coroutine for delay between shooting
            StartCoroutine("AllowToShoot");
            //array with enemies
            //you can put in start, iff all enemies are in the level at beginn (will be not spawn later)
            GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");
            if (allTargets != null)
            {
                Debug.Log(allTargets);
                target = allTargets[0];
                //look for the closest
                foreach (GameObject tmpTarget in allTargets)
                {
                    if (Vector2.Distance(transform.position, tmpTarget.transform.position) < Vector2.Distance(transform.position, target.transform.position))
                    {
                        target = tmpTarget;
                    }
                }
                //shoot if the closest is in the fire range
                if (Vector2.Distance(transform.position, target.transform.position) < shootingDistance)
                {
                    Fire();
                }
            }
        }
    }

    void Fire()
    {
        Vector2 direction = target.transform.position - transform.position;
        //link to spawned arrow, you dont need it, if the arrow has own moving script
        GameObject tmpArrow = Instantiate(arrow, transform.position, transform.rotation);
        tmpArrow.transform.right = direction;
        tmpArrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * speedArrow;
    }

    IEnumerator AllowToShoot()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
