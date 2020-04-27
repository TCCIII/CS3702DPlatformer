using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="EnemyTwoDeath"></typeparam>
    public class EnemyTwoDeath : Simulation.Event<EnemyTwoDeath>
    {
        public EnemyTwoController enemy2;

        public override void Execute()
        {
            enemy2._collider2.enabled = false;
            enemy2.control2.enabled = false;

            if (enemy2._audio2 && enemy2.ouch2)
                enemy2._audio2.PlayOneShot(enemy2.ouch2);
            if (Health.currentHP < Health.maxHP)
            {
                Health.currentHP = Health.currentHP + 1;
                HealthManager.instance.GetHealth();
            }
            ScoreManager.instance.KilledEnemy();
        }
    }
}