﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformgenerator : MonoBehaviour
{
    public GameObject[] spawnPlatforms;
    public GameObject currentPlatform;
    public GameObject nextPlatform;
    int index;

    public Transform generationPoint;
    public float distancebetween = 0;

    private float platformWidth;
    private float platformHeight;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            //Generate next platform
            transform.position = new Vector3(transform.position.x + platformWidth + distancebetween, transform.position.y + platformHeight, transform.position.z);
            Instantiate(nextPlatform, transform.position, transform.rotation);
            
            //Get current platform
            currentPlatform = nextPlatform;
            
            //Get Height and Width of current platform
            platformWidth = GetPlatformWidth(currentPlatform.GetComponent<PolygonCollider2D>());
            platformHeight = GetPlatformHeight(currentPlatform.GetComponent<PolygonCollider2D>());

            //Create next platform
            index = Random.Range(0, spawnPlatforms.Length);
            nextPlatform = spawnPlatforms[index];
        }
        
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
}
