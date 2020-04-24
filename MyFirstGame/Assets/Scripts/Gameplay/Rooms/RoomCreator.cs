using UnityEngine;
using System.Collections;

public class RoomCreator : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject currentPlatform;
    public GameObject nextPlatform;
    int index;

    public float distancebetween = 0;

    private float platformWidth;
    private float platformHeight;

    void Start()
    {
        //Create first platform
        index = Random.Range(0, platforms.Length);
        nextPlatform = platforms[index];

        //Starting Position
        platformWidth = 5;
        platformHeight = 0;
    }

    void Update()
    {
        
    }

    public void PopulateRoom(Transform transform)
    {
        //Choose first platform
        index = Random.Range(0, platforms.Length);
        nextPlatform = platforms[index];

        //Starting Position
        platformWidth = 5;
        platformHeight = 0;

        //Spawn 5 Platforms Total
        for (int i = 0; i < 5; i++)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distancebetween, transform.position.y + platformHeight, transform.position.z);
            Instantiate(platforms[index], transform.position, transform.rotation);

            //Get current platform
            currentPlatform = nextPlatform;

            //Get Height and Width of current platform
            if (currentPlatform.GetComponent<PolygonCollider2D>() == null)
            {
                platformWidth = GetRoomWidth(currentPlatform.GetComponentsInChildren<PolygonCollider2D>());
                platformHeight = GetRoomHeight(currentPlatform.GetComponentsInChildren<PolygonCollider2D>());
            }
            else
            {
                platformWidth = GetPlatformWidth(currentPlatform.GetComponent<PolygonCollider2D>());
                platformHeight = GetPlatformHeight(currentPlatform.GetComponent<PolygonCollider2D>());
            }

            //Create next platform
            index = Random.Range(0, platforms.Length);
            nextPlatform = platforms[index];
        }
        transform.position = new Vector3(transform.position.x + platformWidth + distancebetween, transform.position.y + platformHeight, transform.position.z);
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

    public float GetRoomWidth(PolygonCollider2D[] poly)
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
        return totalX;
    }

    public float GetRoomHeight(PolygonCollider2D[] poly)
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
        return totalY;
    }
}
