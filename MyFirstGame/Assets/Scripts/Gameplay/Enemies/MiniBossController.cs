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
    [RequireComponent(typeof(MiniBossAnimation), typeof(Collider2D))]
    public class MiniBossController : MonoBehaviour
    {
        public PatrolPath path3;
        public AudioClip ouch3;

        internal PatrolPath.Mover mover3;
        internal MiniBossAnimation control3;
        internal Collider2D _collider3;
        internal AudioSource _audio3;
        internal SpriteRenderer _spriteRenderer3;
        public Health health;

        private bool invincible3 = false;

        public Bounds Bounds => _collider3.bounds;

        void Awake()
        {
            control3 = GetComponent<MiniBossAnimation>();
            _collider3 = GetComponent<Collider2D>();
            _audio3 = GetComponent<AudioSource>();
            _spriteRenderer3 = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (!invincible3)
                {
                    var ev = Schedule<PlayerMiniBossCollision>();
                    ev.player = player;
                    ev.enemy3 = this;
                }

            }
        }

        void Update()
        {


            if (path3 != null)
            {
                if (mover3 == null) mover3 = path3.CreateMover(control3.maxSpeed3 * 0.5f);
                control3.move3.x = Mathf.Clamp(mover3.Position.x - transform.position.x, -1, 1);
            }
        }

        public IEnumerator Invulnerability3()
        {

            yield return new WaitForSecondsRealtime(3);
            invincible3 = false;
        }
    }
}

