using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformgenerator : MonoBehaviour
{
    public GameObject thePlatform;

    GameObject[] spawnPlatforms;
    GameObject currentPlatform;
    int index;

    public Transform generationPoint;
    public float distancebetween;

    private float platformWidth; 
    // Start is called before the first frame update
    void Start()
    {
        spawnPlatforms = GameObject.FindGameObjectsWithTag("platform");
        index = Random.Range(0, spawnPlatforms.Length);
        currentPlatform = spawnPlatforms[index];

        platformWidth = currentPlatform.GetComponent<BoxCollider2D>().size.x;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<generationPoint.position.x)
        {
            index = Random.Range(0, spawnPlatforms.Length);
            currentPlatform = spawnPlatforms[index];

            transform.position = new Vector3(transform.position.x + platformWidth + distancebetween, transform.position.y, transform.position.z);
                Instantiate(currentPlatform, transform.position, transform.rotation);
        }
        
    }
}
