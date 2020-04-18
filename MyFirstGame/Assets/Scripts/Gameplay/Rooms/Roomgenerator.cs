using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Roomgenerator : MonoBehaviour
{
    internal RoomCreator populator;

    public GameObject[] spawnRooms;
    public GameObject currentRoom;
    public GameObject nextRoom;
    public GameObject itemStore;
    int index;

    public Transform generationPoint;
    public float distancebetween = 0;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        //Create first room
        index = Random.Range(0, spawnRooms.Length);
        nextRoom = spawnRooms[index];

        //Keep Track of rooms created
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            if (count % 5 == 0)
            {
                //Generate item store
                transform.position = new Vector3(transform.position.x + distancebetween, transform.position.y, transform.position.z);
                Instantiate(itemStore, transform.position, transform.rotation);
                transform.position = new Vector3(transform.position.x + 10 + distancebetween, transform.position.y, transform.position.z);
            }
            else
            {
                //Generate next room
                currentRoom = nextRoom;
                transform.position = new Vector3(transform.position.x + distancebetween, transform.position.y, transform.position.z);
                Instantiate(currentRoom, transform.position, transform.rotation);

                //Populate Room
                populator = currentRoom.GetComponent<RoomCreator>();
                populator.PopulateRoom(transform);

                //Create next room
                index = Random.Range(0, spawnRooms.Length);
                nextRoom = spawnRooms[index];
            }
            count++;
        }

    }
}