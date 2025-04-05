using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Coin : MonoBehaviour
{

    [SerializeField]private float _destroyTime;
    [SerializeField]private float _rotateSpeed;

    private Vector3 _defaultPosition;
    private float _time;



    public abstract int Value{ get;}

    protected virtual void Awake()
    {
        _defaultPosition = transform.position;
        Destroy(gameObject, _destroyTime);
    }

    protected virtual void Update()
    {
        _time += Time.deltaTime * 5;
        transform.Rotate(Vector3.up, _time * _rotateSpeed);
        transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time) / 5;
    }




}
