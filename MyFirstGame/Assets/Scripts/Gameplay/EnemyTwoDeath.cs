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
            enemy2._collider.enabled = false;
            enemy2.control.enabled = false;

            if (enemy2._audio && enemy2.ouch)
                enemy2._audio.PlayOneShot(enemy2.ouch);
        }
    }
}