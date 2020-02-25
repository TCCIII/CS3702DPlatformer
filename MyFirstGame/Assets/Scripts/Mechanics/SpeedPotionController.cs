using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class animates all item instances in a scene.
    /// This allows a single update call to animate hundreds of sprite 
    /// animations.
    /// If the items property is empty, it will automatically find and load 
    /// all item instances in the scene at runtime.
    /// </summary>
    public class SpeedPotionController : MonoBehaviour
    {
        [Tooltip("Frames per second at which items are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of items which are animated. If empty, item instances are found and loaded at runtime.")]
        public SpeedPotionInstance[] speedPotions;

        float nextFrameTime = 0;

        [ContextMenu("Find All Items")]
        void FindAllItemsInScene()
        {
            speedPotions = UnityEngine.Object.FindObjectsOfType<SpeedPotionInstance>();
        }

        void Awake()
        {
            //if items are empty, find all instances.
            //if items are not empty, they've been added at editor time.
            if (speedPotions.Length == 0)
                FindAllItemsInScene();
            //Register all items so they can work with this controller.
            for (var i = 0; i < speedPotions.Length; i++)
            {
                speedPotions[i].speedPotionIndex = i;
                speedPotions[i].controller = this;
            }
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all items with the next animation frame.
                for (var i = 0; i < speedPotions.Length; i++)
                {
                    var speedPotion = speedPotions[i];
                    //if item is null, it has been disabled and is no longer animated.
                    if (speedPotion != null)
                    {
                        speedPotion._renderer.sprite = speedPotion.sprites[speedPotion.frame];
                        if (speedPotion.collected && speedPotion.frame == speedPotion.sprites.Length - 1)
                        {
                            speedPotion.gameObject.SetActive(false);
                            speedPotions[i] = null;
                        }
                        else
                        {
                            speedPotion.frame = (speedPotion.frame + 1) % speedPotion.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}