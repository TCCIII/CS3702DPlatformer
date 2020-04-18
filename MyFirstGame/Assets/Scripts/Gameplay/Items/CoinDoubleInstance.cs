using Platformer.Gameplay;
using UnityEngine;
using Platformer.Model;
using static Platformer.Core.Simulation;
using Plateformer.Mechanics;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class CoinDoubleInstance : MonoBehaviour
    {

        public AudioClip coinDoubCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        internal int coinDoubIndex = -1;
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
            Coin.coinValue = Coin.coinValue + 1;
        }

        public void RemoveAbility()
        {
            Coin.coinValue = Coin.coinValue - 1;
        }

        public void Description()
        {
            string text = "+1 Coin Value";
            ItemDescriptionManager.instance.Description(text);
        }
    }
}