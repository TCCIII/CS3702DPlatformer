﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
            HealthManager.instance.GetHealth();
        }
    }
}