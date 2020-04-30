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

    public MiniBossController enemy1;
    public EnemyTwoController enemy;
    public BossController enemy5;
    public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    public int BossHealth = 20;
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
            if (enemy)
            {
                if (enemy.enemyCHealth > 0)
                {
                    enemy.enemyDamage();
                    if (enemy.enemyCHealth <= 0)
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
        if (collision.gameObject.tag == "Enemy")
        {
            enemy1 = collision.gameObject.GetComponent<MiniBossController>();
            if (enemy1)
            {
                if (enemy1.MCHealth > 0)
                {
                    enemy1.MiniDamage();
                    if (enemy1.MCHealth <= 0)
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
        }
        if (collision.gameObject.tag == "Enemy")
        {
            enemy5 = collision.gameObject.GetComponent<BossController>();
            if (enemy5)
            {
                if (enemy5.BossCHealth > 0)
                {
                    enemy5.BossDamage();
                    if (enemy5.BossCHealth <= 0)
                    {
                        Schedule<BossDeath>().enemy4 = enemy5;
                    }
                }
                else
                {
                    Schedule<BossDeath>().enemy4 = enemy5;
                }

                Destroy(gameObject);
            }
        }
    }
}
