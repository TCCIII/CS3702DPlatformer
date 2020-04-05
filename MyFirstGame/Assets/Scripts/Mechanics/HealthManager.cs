using System.Collections;
using System.Collections.Generic;
using Platformer.Model;
using UnityEngine;
using TMPro;
using static Platformer.Core.Simulation;
using Platformer.Core;

namespace Platformer.Mechanics
{
    public class HealthManager : MonoBehaviour
    {
        public static HealthManager instance;
        public TextMeshProUGUI text;
        public int health;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        // Start is called before the first frame update
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void GetHealth()
        {
            ScoreManager.instance.SetScore(11);
            var player = model.player;

            health = model.player.health.GetHealth();
            text.text = "Health: " + health.ToString();

            ScoreManager.instance.SetScore(health);
        }

        public void GetHealth(int value)
        {
            text.text = "Health: " + value.ToString();
            ScoreManager.instance.SetScore(model.player.health.GetHealth());
        }
    }
}