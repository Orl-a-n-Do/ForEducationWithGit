using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    private void OnTriggerEnter(Collider other)
    {
        BallMovement ballMovement = other.GetComponent<BallMovement>();
        if (ballMovement != null)
        {
            int coinValue = Random.Range(_minValue, _maxValue + 1);
            ballMovement.AddCoin(coinValue);
            gameObject.SetActive(false);
        }
    }
}