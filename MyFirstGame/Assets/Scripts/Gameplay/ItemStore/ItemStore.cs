using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemStore : MonoBehaviour
{
    public GameObject[] RareItems;
    public GameObject[] MythicItems;
    public GameObject[] LegendaryItems;

    public Transform container;
    private Transform shopItemTemplate;

    private int index;

    private void Awake()
    {
        shopItemTemplate = container.Find("DisplayBox");
        shopItemTemplate.gameObject.SetActive(false);

        index = Random.Range(0, RareItems.Length);
        CreateItemButton(RareItems[index].GetComponent<SpriteRenderer>().sprite, 15, -10);
        CreateItemButton(MythicItems[index].GetComponent<SpriteRenderer>().sprite, 30, 0);
        CreateItemButton(LegendaryItems[index].GetComponent<SpriteRenderer>().sprite, 60, 5);
    }

    private void Start()
    {
        index = Random.Range(0, RareItems.Length);
        CreateItemButton(RareItems[index].GetComponent<SpriteRenderer>().sprite, 15, -10);
        CreateItemButton(MythicItems[index].GetComponent<SpriteRenderer>().sprite, 30, 0);
        CreateItemButton(LegendaryItems[index].GetComponent<SpriteRenderer>().sprite, 60, 5);
    }

    private void CreateItemButton(Sprite itemSprite, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemWidth = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(-shopItemWidth * positionIndex, 0);

        shopItemTransform.Find("Cost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

        Debug.Log("Made");
    }

    public void PurchaseItem()
    {
        Debug.Log("Purchased");
    }

    public void ShowStore()
    {

    }
}
