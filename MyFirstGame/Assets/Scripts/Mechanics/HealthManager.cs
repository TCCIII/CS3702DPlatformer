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
        public static int health;

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
            var player = model.player;
            health = player.health.GetHealth();
            text.text = "Health: " + health.ToString();
        }

        public void GetHealth(int value)
        {
            text.text = "Health: " + value.ToString();
        }
    }
}