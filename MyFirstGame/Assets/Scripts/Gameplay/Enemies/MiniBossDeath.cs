using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="MiniBossDeath"></typeparam>
    public class MiniBossDeath : Simulation.Event<MiniBossDeath>
    {
        public MiniBossController enemy3;

        public override void Execute()
        {
            enemy3._collider3.enabled = false;
            enemy3.control3.enabled = false;

            if (enemy3._audio3 && enemy3.ouch3)
                enemy3._audio3.PlayOneShot(enemy3.ouch3);
            if (Health.currentHP < Health.maxHP)
            {
                Health.currentHP = Health.currentHP + 1;
                HealthManager.instance.GetHealth();
            }
            ScoreManager.instance.KilledEnemy();
        }
    }
}

