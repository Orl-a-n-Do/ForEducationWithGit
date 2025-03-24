using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float gameTime = 60f; 
    private float timer;
    private int totalCoins;
    private int collectedCoins;

    void Start()
    {
        timer = gameTime;
        totalCoins = FindObjectsOfType<Coin>().Length;
        collectedCoins = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log("Time left: " + Mathf.Ceil(timer) + " seconds");

        if (timer <= 0)
        {
            EndGame(false);
        }
    }

    public void CollectCoin()
    {
        collectedCoins++;
        if (collectedCoins >= totalCoins)
        {
            EndGame(true);
        }
    }

    private void EndGame(bool won)
    {
        if (won)
        {
            Debug.Log("Вы выиграли!");
        }
        else
        {
            Debug.Log("Вы проиграли!");
        }
        
        Time.timeScale = 0;
    }
}