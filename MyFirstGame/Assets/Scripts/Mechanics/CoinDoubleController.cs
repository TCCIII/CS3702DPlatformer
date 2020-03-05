using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{

    public class CoinDoubleController : MonoBehaviour
    {
        [Tooltip("Frames per second at which items are animated.")]
        public float frameRate = 12;
        [Tooltip("Instances of items which are animated. If empty, item instances are found and loaded at runtime.")]
        public CoinDoubleInstance[] coinDoubs;

        float nextFrameTime = 0;

        [ContextMenu("Find All Items")]
        void FindAllItemsInScene()
        {
            coinDoubs = UnityEngine.Object.FindObjectsOfType<CoinDoubleInstance>();
        }

        void Awake()
        {
            //if items are empty, find all instances.
            //if items are not empty, they've been added at editor time.
            if (coinDoubs.Length == 0)
                FindAllItemsInScene();
            //Register all items so they can work with this controller.
            for (var i = 0; i < coinDoubs.Length; i++)
            {
                coinDoubs[i].coinDoubIndex = i;
                coinDoubs[i].controller = this;
            }
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all items with the next animation frame.
                for (var i = 0; i < coinDoubs.Length; i++)
                {
                    var coinDoub = coinDoubs[i];
                    //if item is null, it has been disabled and is no longer animated.
                    if (coinDoub != null)
                    {
                        coinDoub._renderer.sprite = coinDoub.sprites[coinDoub.frame];
                        if (coinDoub.collected && coinDoub.frame == coinDoub.sprites.Length - 1)
                        {
                            coinDoub.gameObject.SetActive(false);
                            coinDoubs[i] = null;
                        }
                        else
                        {
                            coinDoub.frame = (coinDoub.frame + 1) % coinDoub.sprites.Length;
                        }
                    }
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

    }
}
