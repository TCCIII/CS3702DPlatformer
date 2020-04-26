using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationTwoController), typeof(Collider2D))]
    public class EnemyTwoController : MonoBehaviour
    {
        public PatrolPath path2;
        public AudioClip ouch2;

        internal PatrolPath.Mover mover2;
        internal AnimationTwoController control2;
        internal Collider2D _collider2;
        internal AudioSource _audio2;
        internal SpriteRenderer _spriteRenderer2;
        public Health health;

        private bool invincible2 = false;

        public Bounds Bounds => _collider2.bounds;

        void Awake()
        {
            control2 = GetComponent<AnimationTwoController>();
            _collider2 = GetComponent<Collider2D>();
            _audio2 = GetComponent<AudioSource>();
            _spriteRenderer2 = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (!invincible2)
                {
                    var ev = Schedule<PlayerEnemyTwoCollision>();
                    ev.player = player;
                    ev.enemy2 = this;
                }

            }
        }

        void Update()
        {
            if (path2 != null)
            {
                if (mover2 == null) mover2 = path2.CreateMover(control2.maxSpeed2 * 0.5f);
                control2.move2.x = Mathf.Clamp(mover2.Position.x - transform.position.x, -1, 1);
            }
        }

        public IEnumerator Invulnerability2()
        {

            yield return new WaitForSecondsRealtime(3);
            invincible2 = false;
        }
    }
}









