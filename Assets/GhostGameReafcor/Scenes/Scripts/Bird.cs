using UnityEngine;
using TMPro;
using System;

public class Bird : MonoBehaviour, IJumper, IDiedNotifier
{
  
    public event Action Jumped
    {
        add => _jumper.Jumped += value;
        remove => _jumper.Jumped -= value;
    }

    public event Action Died;
    
    private PhysicsJumper _jumper;
    [SerializeField] private float _jumpForce;
    

    private void FixedUpdate()
    {
        _jumper.FixedUpdate();
    }



    private void Awake()
    {
        _jumper = new PhysicsJumper(_jumpForce, GetComponent<Rigidbody>());


    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumper.Jump(Vector2.up);
            
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        Died?.Invoke();
    }

}
