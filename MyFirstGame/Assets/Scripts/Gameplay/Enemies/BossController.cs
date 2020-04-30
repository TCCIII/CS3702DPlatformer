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
    [RequireComponent(typeof(BossAnimation), typeof(Collider2D))]
    public class BossController : MonoBehaviour
    {
        public PatrolPath path4;
        public AudioClip ouch4;

        internal PatrolPath.Mover mover4;
        internal BossAnimation control4;
        internal Collider2D _collider4;
        internal AudioSource _audio4;
        internal SpriteRenderer _spriteRenderer4;
        public Health health;
        public int BossCHealth = 20;

        private bool invincible4 = false;

        public Bounds Bounds => _collider4.bounds;

        void Awake()
        {
            control4 = GetComponent<BossAnimation>();
            _collider4 = GetComponent<Collider2D>();
            _audio4 = GetComponent<AudioSource>();
            _spriteRenderer4 = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                if (!invincible4)
                {
                    var ev = Schedule<PlayerBossCollision>();
                    ev.player = player;
                    ev.enemy4 = this;
                }

            }
        }

        void Update()
        {


            if (path4 != null)
            {
                if (mover4 == null) mover4 = path4.CreateMover(control4.maxSpeed4 * 0.5f);
                control4.move4.x = Mathf.Clamp(mover4.Position.x - transform.position.x, -1, 1);
            }
        }

        public IEnumerator Invulnerability4()
        {

            yield return new WaitForSecondsRealtime(3);
            invincible4 = false;
        }

        public void BossDamage()
        {
            BossCHealth = BossCHealth - 1;
        }
    }
}










