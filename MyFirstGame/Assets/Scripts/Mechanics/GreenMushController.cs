using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{

    public class GreenMushController : MonoBehaviour
    {
        [Tooltip("Frames per second at which items are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of items which are animated. If empty, item instances are found and loaded at runtime.")]
        public GreenMushInstance[] greenMushes;

        float nextFrameTime = 0;

        [ContextMenu("Find All Items")]
        void FindAllItemsInScene()
        {
            greenMushes = UnityEngine.Object.FindObjectsOfType<GreenMushInstance>();
        }

        void Awake()
        {
            //if items are empty, find all instances.
            //if items are not empty, they've been added at editor time.
            if (greenMushes.Length == 0)
                FindAllItemsInScene();
            //Register all items so they can work with this controller.
            for (var i = 0; i < greenMushes.Length; i++)
            {
                greenMushes[i].greenMushIndex = i;
                greenMushes[i].controller = this;
            }
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all items with the next animation frame.
                for (var i = 0; i < greenMushes.Length; i++)
                {
                    var greenMush = greenMushes[i];
                    //if item is null, it has been disabled and is no longer animated.
                    if (greenMush != null)
                    {
                        greenMush._renderer.sprite = greenMush.sprites[greenMush.frame];
                        if (greenMush.collected && greenMush.frame == greenMush.sprites.Length - 1)
                        {
                            greenMush.gameObject.SetActive(false);
                            greenMushes[i] = null;
                        }
                        else
                        {
                            greenMush.frame = (greenMush.frame + 1) % greenMush.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}