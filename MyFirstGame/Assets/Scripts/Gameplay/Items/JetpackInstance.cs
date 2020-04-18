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
            model.jumpModifier = model.jumpModifier + 0.3f;
        }

        public void RemoveAbility()
        {
            model.jumpModifier = model.jumpModifier - 0.3f;
        }

        public void Description()
        {
            string text = "Decreases gravity of player";
            ItemDescriptionManager.instance.Description(text);
        }
    }
}