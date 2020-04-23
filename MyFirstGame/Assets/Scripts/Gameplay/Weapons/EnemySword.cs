﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    float speed;
    Vector2 direction1;
    bool isReady;


    void Awake()
{
    speed = 5f;
    isReady = false;
}



// Start is called before the first frame update
void Start()
{

}


public void SetDirection(Vector2 direction)
{
    direction1 = direction.normalized;

    isReady = true;

}

   

    // Update is called once per frame
    void Update()
{
    if (isReady)
    {
        Vector2 position = transform.position;

        position += direction1 * speed * Time.deltaTime;

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
            (transform.position.y < min.y) || (transform.position.y > max.y))

        {
            Destroy(gameObject);
        }

          
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "platform" || collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
           
        }
    }

}

