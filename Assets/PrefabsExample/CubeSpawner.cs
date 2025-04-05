using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    
    [SerializeField]private GameObject _cubePrefab;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Vector3 spawnPosition = new Vector3(Random.Range(_minX,_maxX),0,0);

            GameObject gameObject = Instantiate(_cubePrefab, spawnPosition , Quaternion.identity);
            gameObject.transform.position +=  Vector3.up * 3;
        }




        
    }





}
