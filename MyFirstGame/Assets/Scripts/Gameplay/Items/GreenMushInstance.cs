﻿using Platformer.Gameplay;
using UnityEngine;
using Platformer.Model;
using static Platformer.Core.Simulation;
using static Platformer.Mechanics.Health;
using static Platformer.Mechanics.HealthManager;


namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class GreenMushInstance : MonoBehaviour
    {
        
        public AudioClip greenMushCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        internal int greenMushIndex = -1;
        internal GreenMushController controller;
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
            maxHP = maxHP + 1;
            currentHP = currentHP + 1;
            HealthManager.instance.GetHealth();
        }

        public void RemoveAbility()
        {
            if (currentHP > 1)
            {
                maxHP = maxHP - 1;
                currentHP = currentHP - 1;
            }
            HealthManager.instance.GetHealth();
        }
    }
}
