using UnityEngine;
using Platformer.Model;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class JetpackInstance : MonoBehaviour
    {
        readonly PlatformerModel model = Core.Simulation.GetModel<PlatformerModel>();
        public AudioClip jetPackCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;
        public static bool jetpack;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        internal int jetPackIndex = -1;
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
            PlayerController.hasjetpack = true;
        }

        public void RemoveAbility()
        {
            PlayerController.hasjetpack = false;
        }

        public void Description()
        {
            string text = "Allows Player flight for a limited amount of time at the cost of their jump";
            ItemDescriptionManager.instance.Description(text);
        }
    }
}