using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 1);

        Instantiate(item, playerPos, Quaternion.identity);
    }
}
