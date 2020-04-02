using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using static Platformer.Core.Simulation;
using UnityEngine;
namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyTwoCollision"></typeparam>
    public class PlayerEnemyTwoCollision : Simulation.Event<PlayerEnemyTwoCollision>
    {
        public EnemyTwoController enemy2;
        public PlayerController player;

        public PlatformerModel Model = Simulation.GetModel<PlatformerModel>();






        public override void Execute()
        {
            var willHurtEnemyTwo = player.Bounds.center.y >= enemy2.Bounds.max.y;

            if (willHurtEnemyTwo)
            {
                var enemyHealthTwo = enemy2.GetComponent<Health>();
                if (enemyHealthTwo != null)
                {
                    enemyHealthTwo.Decrement();
                    if (!enemyHealthTwo.IsAlive)
                    {
                        Schedule<EnemyTwoDeath>().enemy2 = enemy2;
                        player.Bounce(2);
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




