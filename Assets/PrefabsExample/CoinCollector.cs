using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
   
    private int _coins;


    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();  
        
        if (coin != null)
        {
            Add(coin.Value);
            Destroy(coin.gameObject);    
        }

    }

    public void Add(int coins)
    {
        if(coins < 0)
        {
            Debug.LogError("Coins < 0");
            return;
        }

        _coins += coins;

        Debug.Log($"Монет собрано{_coins}");
    }




}
