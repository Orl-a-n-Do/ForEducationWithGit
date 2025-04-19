using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDragAndDrop 
{
    void PickUpObject(Transform obj);

    void DropObject();
}
