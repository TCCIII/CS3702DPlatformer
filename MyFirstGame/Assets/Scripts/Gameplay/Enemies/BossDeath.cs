using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="BossDeath"></typeparam>
    public class BossDeath : Simulation.Event<BossDeath>
    {
        public BossController enemy4;

        public override void Execute()
        {
            enemy4._collider4.enabled = false;
            enemy4.control4.enabled = false;

            if (enemy4._audio4 && enemy4.ouch4)
                enemy4._audio4.PlayOneShot(enemy4.ouch4);
            if (Health.currentHP < Health.maxHP)
            {
                Health.currentHP = Health.currentHP + 1;
                HealthManager.instance.GetHealth();
            }
            ScoreManager.instance.KilledEnemy();
        }
    }
}