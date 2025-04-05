using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour
{
   
    [SerializeField]private float _rotateSpeed;

    private Vector3 _defaultPosition;
    private float _time;

    public abstract void Use();

    public abstract int Value{ get;}

    public abstract void PlayParticleEffect();




    protected virtual void Awake()
    {
        _defaultPosition = transform.position;
    }

    protected virtual void Update()
    {
        _time += Time.deltaTime * 5;
        
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);

      //  transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time) / 5;
    }

  
}
