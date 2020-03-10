using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
        /*if (Input.GetButtonDown("Inventory1"))
        {

        }
        if (Input.GetButtonDown("Inventory2"))
        {

        }
        if (Input.GetButtonDown("Inventory3"))
        {

        }
        if (Input.GetButtonDown("Inventory4"))
        {

        }
        if (Input.GetButtonDown("Inventory5"))
        {

        }*/
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}