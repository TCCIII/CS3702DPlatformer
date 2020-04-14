using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDescription : MonoBehaviour
{
    public UnityEvent itemInstance;

    private void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            itemInstance.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ItemDescriptionManager.instance.Clear();
        }
    }

    void Description(string text)
    {
        ItemDescriptionManager.instance.Description(text);
    }
}
