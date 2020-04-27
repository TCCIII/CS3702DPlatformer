using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public GameObject DeathScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        DeathScreen.SetActive(false);
    }

    public void DisplayScore()
    {
        DeathScreen.SetActive(true);
    }
}