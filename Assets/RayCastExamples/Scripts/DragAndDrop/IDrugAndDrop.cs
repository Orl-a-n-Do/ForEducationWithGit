using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDragAndDrop 
{
    void PickUpObject(Rigidbody obj);

    void DropObject();

    void Update();
}
