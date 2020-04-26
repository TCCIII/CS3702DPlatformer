using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using Platformer.Gameplay;
using UnityEngine;
using Platformer.Core;
using Platformer.Model;
using System;


public class EnemyFire : MonoBehaviour
{
    public GameObject EnemySword;
    float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        GameObject player = GameObject.Find("Player");

       if (Time.time > nextFire)
        {
           /* Instantiate(EnemySword, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;*/

            if (player != null)

            {


                GameObject sword = (GameObject)Instantiate(EnemySword);

                sword.transform.position = transform.position;

                Vector2 direction = player.transform.position - sword.transform.position;
                nextFire = Time.time + fireRate;
                sword.GetComponent<EnemySword>().SetDirection(direction);

            }
        }

   
    }


}


