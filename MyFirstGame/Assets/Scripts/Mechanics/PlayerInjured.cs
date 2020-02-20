using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerInjured"></typeparam>
    public class PlayerInjured : Simulation.Event<PlayerInjured>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.health.Injured();
            HealthManager.instance.GetHealth();

            if (!player.health.IsAlive)
            {
                Schedule<PlayerDeath>();
            }

            if (player.audioSource && player.ouchAudio)
            {
                player.audioSource.PlayOneShot(player.ouchAudio);
            }
            player.animator.SetTrigger("hurt");
        }
    }
}