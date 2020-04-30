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
    public BossController enemy2;
    public MiniBossController enemy1;
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

        if (collision.gameObject.tag == "Enemy")
        {
            enemy1 = collision.gameObject.GetComponent<MiniBossController>();
            var enemyHealth = enemy1.GetComponent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Schedule<MiniBossDeath>().enemy3 = enemy1;
                }
            }
            else
            {
                Schedule<MiniBossDeath>().enemy3 = enemy1;
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemy2 = collision.gameObject.GetComponent<BossController>();
            var enemyHealth = enemy2.GetComponent<Health>();

            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Schedule<BossDeath>().enemy4 = enemy2;
                }
            }
            else
            {
                Schedule<BossDeath>().enemy4 = enemy2;
            }

            Destroy(gameObject);
        }
    }
}
