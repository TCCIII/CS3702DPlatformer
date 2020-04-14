using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDescriptionManager : MonoBehaviour
{
	public static ItemDescriptionManager instance;
	public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

    public void Description()
    {
        text.text = "";
    }

    public void Description(string description)
    {
        text.text = description;
    }

    public void Clear()
    {
        text.text = "";
    }
}
