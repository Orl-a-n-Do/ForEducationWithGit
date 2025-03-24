using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
   
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    


    private void OnTriggerEnter(Collider other)
    {
        BallMovement ballMovement = other.GetComponent<BallMovement>();
        if(ballMovement != null)
        {
            ballMovement.AddCoin(Random.Range(0, _maxValue + 1));
            gameObject.SetActive(false);
        }

    }


}
