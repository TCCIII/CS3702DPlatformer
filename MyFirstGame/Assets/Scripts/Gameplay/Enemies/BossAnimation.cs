using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// AnimationController integrates physics and animation. It is generally used for simple enemy animation.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class BossAnimation : KinematicObject
    {
        /// <summary>
        /// Max horizontal speed.
        /// </summary>
        public float maxSpeed4 = 7;

        /// <summary>
        /// Max jump velocity
        /// </summary>
        public float jumpTakeOffSpeed4 = 7;

        /// <summary>
        /// Used to indicated desired direction of travel.
        /// </summary>
        public Vector2 move4;

        /// <summary>
        /// Set to true to initiate a jump.
        /// </summary>
        public bool jump4;

        /// <summary>
        /// Set to true to set the current jump velocity to zero.
        /// </summary>
        public bool stopJump4;

        SpriteRenderer spriteRenderer4;
        Animator animator4;
        readonly PlatformerModel Model = Simulation.GetModel<PlatformerModel>();

        protected virtual void Awake()
        {
            spriteRenderer4 = GetComponent<SpriteRenderer>();
            animator4 = GetComponent<Animator>();
        }

        protected override void ComputeVelocity()
        {
            if (jump4 && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed4 * Model.jumpModifier;
                jump4 = false;
            }
            else if (stopJump4)
            {
                stopJump4 = false;
                if (velocity.y > 0)
                {
                    velocity.y *= Model.jumpDeceleration;
                }
            }

            if (move4.x > 0.01f)
                spriteRenderer4.flipX = false;
            else if (move4.x < -0.01f)
                spriteRenderer4.flipX = true;

            animator4.SetBool("grounded", IsGrounded);
            animator4.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed4);

            targetVelocity = move4 * maxSpeed4;
        }
    }
}






