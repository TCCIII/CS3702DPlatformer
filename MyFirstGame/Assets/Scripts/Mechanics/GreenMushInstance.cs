using Platformer.Gameplay;
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

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this item.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);

            if (other.gameObject.tag == "Player")
            {
                //Destroy(gameObject);
            }
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            //disable the gameObject and remove it from the controller update list.
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;
            //send an event into the gameplay system to perform some behaviour.
            var ev = Schedule<PlayerItemCollision>();
            ev.greenMush = this;
            ev.player = player;
            maxHP = 5;
            currentHP = 5;
            HealthManager.instance.GetHealth();
            player.health.Increment();
        }
    }
}
