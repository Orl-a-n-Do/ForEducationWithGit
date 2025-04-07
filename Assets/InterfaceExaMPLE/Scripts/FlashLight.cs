using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour, IInteractable
{

    [SerializeField]private Light _pointLight;
    public void Interact()
    {
        _pointLight.enabled = !_pointLight.enabled;
    }

}
