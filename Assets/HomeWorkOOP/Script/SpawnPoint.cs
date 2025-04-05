using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Items _item;

    public bool isEmpty
    {
        get
        {
            if(_item == null)
                return true;

            if(_item.gameObject == null)
                return true;

            return false;
        }
    }

    public Vector3 Position => transform.position;

    
    public void Occupy(Items item)
    {
        _item = item;
    }

}
