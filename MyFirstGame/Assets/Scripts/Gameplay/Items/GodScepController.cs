using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
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
    public class GodScepController : MonoBehaviour
    {
        [Tooltip("Frames per second at which items are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of items which are animated. If empty, item instances are found and loaded at runtime.")]
        public GodScepInstance[] GodSceps;

        float nextFrameTime = 0;

        [ContextMenu("Find All Items")]
        void FindAllItemsInScene()
        {
            GodSceps = UnityEngine.Object.FindObjectsOfType<GodScepInstance>();
        }

        void Awake()
        {
            //if items are empty, find all instances.
            //if items are not empty, they've been added at editor time.
            if (GodSceps.Length == 0)
                FindAllItemsInScene();
            //Register all items so they can work with this controller.
            for (var i = 0; i < GodSceps.Length; i++)
            {
                GodSceps[i].GodScepIndex = i;
                GodSceps[i].controller = this;
            }
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all items with the next animation frame.
                for (var i = 0; i < GodSceps.Length; i++)
                {
                    var GodScep = GodSceps[i];
                    //if item is null, it has been disabled and is no longer animated.
                    if (GodScep != null)
                    {
                        GodScep._renderer.sprite = GodScep.sprites[GodScep.frame];
                        if (GodScep.collected && GodScep.frame == GodScep.sprites.Length - 1)
                        {
                            GodScep.gameObject.SetActive(false);
                            GodSceps[i] = null;
                        }
                        else
                        {
                            GodScep.frame = (GodScep.frame + 1) % GodScep.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}
