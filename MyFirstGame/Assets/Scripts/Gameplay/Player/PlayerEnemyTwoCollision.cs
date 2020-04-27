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
    public class PlayerEnemyTwoCollision : Simulation.Event<PlayerEnemyTwoCollision>
    {
        public EnemyTwoController enemy2;
        public PlayerController player;

        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
       
        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy2.Bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy2.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyTwoDeath>().enemy2 = enemy2;
                        player.Bounce(2);
                        ScoreManager.instance.KilledEnemy();
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<EnemyTwoDeath>().enemy2 = enemy2;
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