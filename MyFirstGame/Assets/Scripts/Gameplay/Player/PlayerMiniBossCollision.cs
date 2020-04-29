using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerMiniBossCollision : Simulation.Event<PlayerMiniBossCollision>
    {
        public MiniBossController enemy3;
        public PlayerController player;

        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy3.Bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy3.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<MiniBossDeath>().enemy3 = enemy3;
                        player.Bounce(2);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<MiniBossDeath>().enemy3 = enemy3;
                    player.Bounce(2);
                }
            }
            else
            {
                Schedule<PlayerInjured>();
            }
        }
    }
}





