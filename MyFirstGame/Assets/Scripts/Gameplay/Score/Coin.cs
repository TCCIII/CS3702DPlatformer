using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;

namespace Plateformer.Mechanics
{
    public class Coin : MonoBehaviour
    {
        public static int coinValue = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CoinManager.instance.ChangeScore(coinValue);
                ScoreManager.instance.CollectCoin(coinValue);
            }
        }
    }
}