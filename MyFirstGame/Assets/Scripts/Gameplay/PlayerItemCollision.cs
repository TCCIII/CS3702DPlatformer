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
    public class PlayerItemCollision : Simulation.Event<PlayerItemCollision>
    {
        public PlayerController player;
        public JumpBootsInstance jumpBoots;
        public CoinDoubleInstance coinDoub;
        public GreenMushInstance greenMush;
        public JetpackInstance jetPack;
        public SpeedPotionInstance speedPotion;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(jumpBoots.jumpBootsCollectAudio, jumpBoots.transform.position);
        }
    }
}