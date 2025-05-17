using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesExample : MonoBehaviour
{


    private void Awake()
    {
        TestDelegate testDelegate = new TestDelegate(Sum);
        ShowOperationResult(testDelegate, 4, 5);

    }


    private int Sum(int a, int b) => a + b;
    

    private int Multiply(int a, int b) => a * b;
   
    private int Substract(int a, int b) => a - b;

    private void ShowOperationResult(TestDelegate operation, int firstNumber, int secondNumber )
    {

        int result = operation.Invoke(firstNumber, secondNumber); 
        Debug.Log(result);

    }
    
}
