using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{

    public class PlayerGodScepCollision : Simulation.Event<PlayerItemCollision>
    {
        public PlayerController player;
        public GodScepInstance GodScept;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(GodScept.GodScepCollectAudio, GodScept.transform.position);
        }
    }
}