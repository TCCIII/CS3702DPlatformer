using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{

    public class PlayerGreenMushCollision : Simulation.Event<PlayerItemCollision>
    {
        public PlayerController player;
        public GreenMushInstance greenMush;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(greenMush.greenMushCollectAudio, greenMush.transform.position);
        }
    }
}
