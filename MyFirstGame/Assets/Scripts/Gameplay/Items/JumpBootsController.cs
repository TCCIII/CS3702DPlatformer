using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class animates all item instances in a scene.
    /// This allows a single update call to animate hundreds of sprite 
    /// animations.
    /// If the items property is empty, it will automatically find and load 
    /// all item instances in the scene at runtime.
    /// </summary>
    public class JumpBootsController : MonoBehaviour
    {
        [Tooltip("Frames per second at which items are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of items which are animated. If empty, item instances are found and loaded at runtime.")]
        public JumpBootsInstance[] jumpBoots;

        float nextFrameTime = 0;

        [ContextMenu("Find All Items")]
        void FindAllItemsInScene()
        {
            jumpBoots = UnityEngine.Object.FindObjectsOfType<JumpBootsInstance>();
        }

        void Awake()
        {
            //if items are empty, find all instances.
            //if items are not empty, they've been added at editor time.
            if (jumpBoots.Length == 0)
                FindAllItemsInScene();
            //Register all items so they can work with this controller.
            for (var i = 0; i < jumpBoots.Length; i++)
            {
                jumpBoots[i].jumpBootsIndex = i;
                jumpBoots[i].controller = this;
            }
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all items with the next animation frame.
                for (var i = 0; i < jumpBoots.Length; i++)
                {
                    var jumpBoot = jumpBoots[i];
                    //if item is null, it has been disabled and is no longer animated.
                    if (jumpBoot != null)
                    {
                        jumpBoot._renderer.sprite = jumpBoot.sprites[jumpBoot.frame];
                        if (jumpBoot.collected && jumpBoot.frame == jumpBoot.sprites.Length - 1)
                        {
                            jumpBoot.gameObject.SetActive(false);
                            jumpBoots[i] = null;
                        }
                        else
                        {
                            jumpBoot.frame = (jumpBoot.frame + 1) % jumpBoot.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}