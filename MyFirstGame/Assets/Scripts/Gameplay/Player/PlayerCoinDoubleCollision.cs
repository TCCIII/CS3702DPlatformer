using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{

    public class PlayerCoinDoubleCollision : Simulation.Event<PlayerItemCollision>
    {
        public PlayerController player;
        public CoinDoubleInstance coinDoub;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(coinDoub.coinDoubCollectAudio, coinDoub.transform.position);
        }
    }
}
