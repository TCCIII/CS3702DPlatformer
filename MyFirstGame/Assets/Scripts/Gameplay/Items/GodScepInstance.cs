using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using Platformer.Model;
using static Platformer.Core.Simulation;
using static Platformer.Mechanics.Health;
using static Platformer.Mechanics.HealthManager;

namespace Platformer.Mechanics
{
    public class GodScepInstance : MonoBehaviour
    {
        readonly PlatformerModel model = Core.Simulation.GetModel<PlatformerModel>();
        public AudioClip GodScepCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        internal int GodScepIndex = -1;
        internal GodScepController controller;
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        public void AddAbility()
        {
            ItemDescriptionManager.instance.Clear();
            model.player.maxSpeed = model.player.maxSpeed + 1;
            model.jumpModifier = model.jumpModifier + 0.2f;
            if (currentHP > 2)
            {
                currentHP = currentHP - 2;
            }
            else
            {
                currentHP = 1;
            }
            HealthManager.instance.GetHealth();
            model.player.jumpTakeOffSpeed = model.player.jumpTakeOffSpeed + 1;
        }

        public void RemoveAbility()
        {
            model.player.maxSpeed = model.player.maxSpeed - 1;
            model.jumpModifier = model.jumpModifier - 0.2f;

            //Need to check multiple scepters!!
            currentHP = currentHP + 2;

            HealthManager.instance.GetHealth();
            model.player.jumpTakeOffSpeed = model.player.jumpTakeOffSpeed - 1;
        }

        public void Description()
        {
            string text = "+1 Speed, +1 Jump, Jetpack, -2 Health";
            ItemDescriptionManager.instance.Description(text);
        }
    }
}