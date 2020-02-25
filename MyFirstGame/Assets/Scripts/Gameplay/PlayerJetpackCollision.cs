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
    public class PlayerJetpackCollision : Simulation.Event<PlayerJetpackCollision>
    {
        public PlayerController player;
        public JetpackInstance jetPack;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(jetPack.jetPackCollectAudio, jetPack.transform.position);
        }
    }
}