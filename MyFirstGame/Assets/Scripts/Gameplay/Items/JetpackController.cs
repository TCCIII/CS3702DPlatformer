using UnityEngine;
using Platformer.Model;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class animates all item instances in a scene.
    /// This allows a single update call to animate hundreds of sprite 
    /// animations.
    /// If the items property is empty, it will automatically find and load 
    /// all item instances in the scene at runtime.
    /// </summary>
    public class JetpackController : MonoBehaviour
    {
        [Tooltip("Frames per second at which items are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of items which are animated. If empty, item instances are found and loaded at runtime.")]
        public JetpackInstance[] jetPacks;

        float nextFrameTime = 0;

        [ContextMenu("Find All Items")]
        void FindAllItemsInScene()
        {
            jetPacks = UnityEngine.Object.FindObjectsOfType<JetpackInstance>();
        }

        void Awake()
        {
            //if items are empty, find all instances.
            //if items are not empty, they've been added at editor time.
            if (jetPacks.Length == 0)
                FindAllItemsInScene();
            //Register all items so they can work with this controller.
            for (var i = 0; i < jetPacks.Length; i++)
            {
                jetPacks[i].jetPackIndex = i;
                jetPacks[i].controller = this;
            }
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all items with the next animation frame.
                for (var i = 0; i < jetPacks.Length; i++)
                {
                    var jetPack = jetPacks[i];
                    //if item is null, it has been disabled and is no longer animated.
                    if (jetPack != null)
                    {
                        jetPack._renderer.sprite = jetPack.sprites[jetPack.frame];
                        if (jetPack.collected && jetPack.frame == jetPack.sprites.Length - 1)
                        {
                            jetPack.gameObject.SetActive(false);
                            jetPacks[i] = null;
                        }
                        else
                        {
                            jetPack.frame = (jetPack.frame + 1) % jetPack.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}