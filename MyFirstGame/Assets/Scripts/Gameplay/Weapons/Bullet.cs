using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using Platformer.Gameplay;
using UnityEngine;
using Platformer.Core;
using static Platformer.Core.Simulation;
using Platformer.Model;
using System;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    public EnemyTwoController enemy;
    public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "platform" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyTwoController>();
            var enemyHealth = enemy.GetComponent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Schedule<EnemyTwoDeath>().enemy2 = enemy;
                }
            }
            else
            {
                Schedule<EnemyTwoDeath>().enemy2 = enemy;
            }

            Destroy(gameObject);
        }
    }
}
