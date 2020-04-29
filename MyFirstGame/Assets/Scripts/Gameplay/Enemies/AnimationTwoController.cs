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
    public class AnimationTwoController : KinematicObject
    {
        /// <summary>
        /// Max horizontal speed.
        /// </summary>
        public float maxSpeed2 = 7;
     
        /// <summary>
        /// Max jump velocity
        /// </summary>
        public float jumpTakeOffSpeed2 = 7;

        /// <summary>
        /// Used to indicated desired direction of travel.
        /// </summary>
        public Vector2 move2;
       
        /// <summary>
        /// Set to true to initiate a jump.
        /// </summary>
        public bool jump2;

        /// <summary>
        /// Set to true to set the current jump velocity to zero.
        /// </summary>
        public bool stopJump2;

        SpriteRenderer spriteRenderer2;
        Animator animator2;
        readonly PlatformerModel Model = Simulation.GetModel<PlatformerModel>();

        protected virtual void Awake()
        {
            spriteRenderer2 = GetComponent<SpriteRenderer>();
            animator2 = GetComponent<Animator>();
        }

        protected override void ComputeVelocity()
        {
            if (jump2 && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed2 * Model.jumpModifier;
                jump2 = false;
            }
            else if (stopJump2)
            {
                stopJump2 = false;
                if (velocity.y > 0)
                {
                    velocity.y *= Model.jumpDeceleration;
                }
            }

            if (move2.x > 0.01f)
                spriteRenderer2.flipX = false;
            else if (move2.x < -0.01f)
                spriteRenderer2.flipX = true;

            animator2.SetBool("grounded", IsGrounded);
            animator2.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed2);

            targetVelocity = move2 * maxSpeed2;
        }
    }
}






