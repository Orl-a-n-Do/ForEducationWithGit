using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : Coin
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    private float _timeToChangeMaterial;

    [SerializeField] private Material _newMaterial;
    private MeshRenderer _meshRenderer;


    public override int Value => Random.Range(_minValue, _maxValue) ;


    protected override void Awake()
    {
        base.Awake();
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    protected override void Update()
    {
        base.Update();
        _timeToChangeMaterial += Time.deltaTime;

        if(_timeToChangeMaterial > 2)
           _meshRenderer.material = _newMaterial; 
            //Смена материала
    }







}
