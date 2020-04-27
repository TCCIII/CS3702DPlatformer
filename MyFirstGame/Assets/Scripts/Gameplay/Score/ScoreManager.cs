using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI roomsText;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI totalPoints;

    public int score;
    public int rooms;
    public int enemies;
    public int coins;

    // Use this for initialization
    void Start()
    {
        score = -1;
        rooms = -1;
        enemies = 0;
        coins = 0;

        if (instance == null)
        {
            instance = this;
        }
    }

    public void CollectPoint()
    {
        score++;
        roomsText.text = rooms.ToString();
        enemiesText.text = enemies.ToString();
        coinsText.text = coins.ToString();
        totalPoints.text = "Total Score: " + score.ToString();
    }

    public void CollectPoint(int i)
    {
        score += i;
        roomsText.text = rooms.ToString();
        enemiesText.text = enemies.ToString();
        coinsText.text = coins.ToString();
        totalPoints.text = score.ToString();
    }

    public void FinishRoom()
    {
        rooms++;
        CollectPoint();
    }

    public void KilledEnemy()
    {
        enemies++;
        CollectPoint();
    }

    public void CollectCoin()
    {
        coins++;
        CollectPoint();
    }
}
