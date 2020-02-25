using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a item.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerSpeedPotionCollision : Simulation.Event<PlayerSpeedPotionCollision>
    {
        public PlayerController player;
        public SpeedPotionInstance speedPotion;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(speedPotion.speedPotionCollectAudio, speedPotion.transform.position);
        }
    }
}