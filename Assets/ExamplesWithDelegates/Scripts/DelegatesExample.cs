using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesExample : MonoBehaviour
{


    private void Awake()
    {
        TestDelegate testDelegate = new TestDelegate(Sum);

        testDelegate -= Sum;
       


       if(testDelegate != null)
            testDelegate(4, 5);

        testDelegate?.Invoke(4, 2);    
            
        // int result = testDelegate(5,3);
        // Debug.Log(result);
    }


    private int Sum(int a, int b)
    {
        int result = a + b;
        Debug.Log("Сумма" + result);

        return result;
    }

    private int Multiply(int a, int b)
    {
        int result = a * b;
        Debug.Log("Умножение" + result);

        return result;
    }
    private int Substract(int a, int b)
    {
        int result = a - b;
        Debug.Log("Вычитание" + result);

        return result;
    }
}
