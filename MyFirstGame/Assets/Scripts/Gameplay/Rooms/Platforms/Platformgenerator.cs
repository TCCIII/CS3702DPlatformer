using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformgenerator : MonoBehaviour
{
    public GameObject[] spawnPlatforms;
    public GameObject currentPlatform;
    public GameObject nextPlatform;
    public GameObject itemStore;
    int index;

    public Transform generationPoint;
    public float distancebetween = 0;

    private float platformWidth;
    private float platformHeight;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        //Array of platforms
        spawnPlatforms = GameObject.FindGameObjectsWithTag("platform");

        //Create first platform
        index = Random.Range(0, spawnPlatforms.Length);
        nextPlatform = spawnPlatforms[index];

        //Starting Position
        platformWidth = 0;
        platformHeight = 0;

        //Keep Track of platforms created
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            if (count % 10 == 0)
            {
                //Generate item store
                transform.position = new Vector3(transform.position.x + platformWidth + distancebetween, transform.position.y + platformHeight, transform.position.z);
                Instantiate(itemStore, transform.position, transform.rotation);

                //Get Height and Width of current platform
                platformWidth = GetPlatformWidth(itemStore.GetComponent<PolygonCollider2D>());
                platformHeight = GetPlatformHeight(itemStore.GetComponent<PolygonCollider2D>());
            } else
            {
                //Generate next platform
                transform.position = new Vector3(transform.position.x + platformWidth + distancebetween, transform.position.y + platformHeight, transform.position.z);
                Instantiate(nextPlatform, transform.position, transform.rotation);

                //Get current platform
                currentPlatform = nextPlatform;

                //Get Height and Width of current platform
                if(currentPlatform.GetComponent<PolygonCollider2D>() == null)
                {
                    platformWidth = GetRoomWidth(currentPlatform.GetComponentsInChildren<PolygonCollider2D>());
                    platformHeight = GetRoomHeight(currentPlatform.GetComponentsInChildren<PolygonCollider2D>());
                } else
                {
                    platformWidth = GetPlatformWidth(currentPlatform.GetComponent<PolygonCollider2D>());
                    platformHeight = GetPlatformHeight(currentPlatform.GetComponent<PolygonCollider2D>());
                }
                

                //Create next platform
                index = Random.Range(0, spawnPlatforms.Length);
                nextPlatform = spawnPlatforms[index];
            }
            count++;
        }
        
    }

    public void PopulateRoom(GameObject room)
    {
        Debug.Log("Populate it!");
    }

    float GetPlatformWidth(PolygonCollider2D poly)
    {
        Vector2[] path;
        float maxX = 0;

        //Traverse each path
        for (int pathIndex = 0; pathIndex < poly.pathCount; pathIndex++)
        {
            path = poly.GetPath(pathIndex);

            //Traverse each point within the path
            foreach (Vector2 point in path)
            {
                //Check for maxX
                if (point.x >= maxX)
                {
                    maxX = point.x;
                }
            }
        }
        return maxX;
    }

    float GetPlatformHeight(PolygonCollider2D poly)
    {
        Vector2[] path;
        float maxX = 0;
        float endY = -99;

        //Traverse each path
        for (int pathIndex = 0; pathIndex < poly.pathCount; pathIndex++)
        {
            path = poly.GetPath(pathIndex);
            //Traverse each point within the path
            foreach (Vector2 point in path)
            {
                //Check for maxX
                if (point.x >= maxX)
                {
                    maxX = point.x;
                }
            }
        }
        //Now with maxX, check for the height
        //Traverse each path
        for (int pathIndex = 0; pathIndex < poly.pathCount; pathIndex++)
        {
            path = poly.GetPath(pathIndex);
            //Traverse each point within the path
            foreach (Vector2 point in path)
            {
                //Check if end of platform
                if (point.x >= maxX)
                {
                    //Check for maxY
                    if (point.y >= endY)
                    {
                        endY = point.y;
                    }
                }
            }
        }
        return endY;
    }

    float GetRoomWidth(PolygonCollider2D[] poly)
    {
        Vector2[] path;
        float maxX = 0;
        float totalX = 0;

        for (int polyIndex = 0; polyIndex < poly.Length; polyIndex++)
        {
            //Traverse each path
            for (int pathIndex = 0; pathIndex < poly[polyIndex].pathCount; pathIndex++)
            {
                path = poly[polyIndex].GetPath(pathIndex);

                //Traverse each point within the path
                foreach (Vector2 point in path)
                {
                    //Check for maxX
                    if (point.x >= maxX)
                    {
                        maxX = point.x;
                    }
                }
            }
            totalX += maxX;
            maxX = 0;
        }
        Debug.Log("X: " + totalX);
        return totalX;
    }

    float GetRoomHeight(PolygonCollider2D[] poly)
    {
        Vector2[] path;
        float maxX = 0;
        float endY = -99;
        float totalY = 0;

        for (int polyIndex = 0; polyIndex < poly.Length; polyIndex++)
        {
            //Traverse each path
            for (int pathIndex = 0; pathIndex < poly[polyIndex].pathCount; pathIndex++)
            {
                path = poly[polyIndex].GetPath(pathIndex);
                //Traverse each point within the path
                foreach (Vector2 point in path)
                {
                    //Check for maxX
                    if (point.x >= maxX)
                    {
                        maxX = point.x;
                    }
                }
            }
            //Now with maxX, check for the height
            //Traverse each path
            for (int pathIndex = 0; pathIndex < poly[polyIndex].pathCount; pathIndex++)
            {
                path = poly[polyIndex].GetPath(pathIndex);
                //Traverse each point within the path
                foreach (Vector2 point in path)
                {
                    //Check if end of platform
                    if (point.x >= maxX)
                    {
                        //Check for maxY
                        if (point.y >= endY)
                        {
                            endY = point.y;
                        }
                    }
                }
            }
            totalY += endY;
            endY = -99;
        }
        Debug.Log("Y: "+ totalY);
        return totalY;
    }
}
