using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInBoundaryGame : MonoBehaviour
{
    private string LooeseMessage = "Game Over";
    [SerializeField] Bird _bird;

    [SerializeField] private GameObject _upperBoundary;
    [SerializeField] private GameObject _lowerBoundary;


    [SerializeField] private float _upperYLimit;
    [SerializeField] private float _lowerYLimit;

    private bool _isRunning;

    private void Awake()
    {

        _isRunning = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartGame();

        if (_isRunning == false)
            return;

        if (IsOutOfBoundary())
        {
            LooseGame();
        }
    }

    public bool IsOutOfBoundary()
    {
        return _bird.transform.position.y > _upperYLimit || _bird.transform.position.y < _lowerYLimit;
    }

    public void StartGame()
    {
        _bird.gameObject.SetActive(true);
        _bird.transform.position = new Vector3(0, 0, 0);
        _bird.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        _bird.ResetJumpCount();

        _upperBoundary.transform.position = new Vector3(0, _upperYLimit, 0);
        _lowerBoundary.transform.position = new Vector3(0, _lowerYLimit, 0);

        _isRunning = true;
    }
    
    public void LooseGame()
    {
        _bird.Kill();
        Debug.Log(LooeseMessage);
        Debug.Log($"Final Score:{_bird.JumpCount}");
        _isRunning = false;
    }


}
