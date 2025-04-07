using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{

    private bool _isInteracted;
    private float _currentScale;


    public void Interact()
    {
        _currentScale = transform.localScale.y;
        _isInteracted = true;
    }

    private void Update()
    {
        if(_isInteracted == false)
           return; 

        if(_currentScale <= 0)
            Destroy(gameObject);

        _currentScale -= Time.deltaTime * 10;    

        transform.localScale = new Vector3( _currentScale, _currentScale, _currentScale);
    }


}
