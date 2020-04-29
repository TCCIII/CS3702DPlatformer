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
    public class MiniBossAnimation : KinematicObject
    {
        /// <summary>
        /// Max horizontal speed.
        /// </summary>
        public float maxSpeed3 = 7;
        /// <summary>
        /// Max jump velocity
        /// </summary>
        public float jumpTakeOffSpeed3 = 7;

        /// <summary>
        /// Used to indicated desired direction of travel.
        /// </summary>
        public Vector2 move3;

        /// <summary>
        /// Set to true to initiate a jump.
        /// </summary>
        public bool jump3;

        /// <summary>
        /// Set to true to set the current jump velocity to zero.
        /// </summary>
        public bool stopJump3;

        SpriteRenderer spriteRenderer3;
        Animator animator3;
        readonly PlatformerModel Model = Simulation.GetModel<PlatformerModel>();

        protected virtual void Awake()
        {
            spriteRenderer3 = GetComponent<SpriteRenderer>();
            animator3 = GetComponent<Animator>();
        }

        protected override void ComputeVelocity()
        {
            if (jump3 && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed3 * Model.jumpModifier;
                jump3 = false;
            }
            else if (stopJump3)
            {
                stopJump3 = false;
                if (velocity.y > 0)
                {
                    velocity.y *= Model.jumpDeceleration;
                }
            }

            if (move3.x > 0.01f)
                spriteRenderer3.flipX = false;
            else if (move3.x < -0.01f)
                spriteRenderer3.flipX = true;

            animator3.SetBool("grounded", IsGrounded);
            animator3.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed3);

            targetVelocity = move3 * maxSpeed3;
        }
    }
}

