using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using Platformer.Gameplay;
using UnityEngine;
using Platformer.Core;
using Platformer.Model;
using System;


public class EnemyWaveFire : MonoBehaviour
{
    public GameObject EnemyWaveGO;
    float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1.5f;
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
                GameObject wave = (GameObject)Instantiate(EnemyWaveGO);

                wave.transform.position = transform.position;

                Vector2 direction = player.transform.position - wave.transform.position;
                nextFire = Time.time + fireRate;
                wave.GetComponent<EnemyWave>().SetDirection(direction);

            }
        }
    }
}



