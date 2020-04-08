using Platformer.Gameplay;
using UnityEngine;
using Platformer.Model;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// JumpBootsController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class JumpBootsInstance : MonoBehaviour
    {
        readonly PlatformerModel model = Core.Simulation.GetModel<PlatformerModel>();
        public AudioClip jumpBootsCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        //unique index which is assigned by the JumpBootsController in a scene.
        internal int jumpBootsIndex = -1;
        internal JumpBootsController controller;
        //active frame in animation, updated by the controller.
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
            model.player.jumpTakeOffSpeed = model.player.jumpTakeOffSpeed + 2;
        }

        public void RemoveAbility()
        {
            model.player.jumpTakeOffSpeed = model.player.jumpTakeOffSpeed - 2;
        }
    }
}