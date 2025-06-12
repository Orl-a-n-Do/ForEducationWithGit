using UnityEngine;
using TMPro;

public class JumpCounterView : MonoBehaviour
{
    private JumpCounter _jumpCounter;
    [SerializeField] private TMP_Text _text;


    public void Initialize(JumpCounter jumpCounter)
    {
        _jumpCounter = jumpCounter;

        _jumpCounter.Changed += OnJumpCounterChanged;
    }

    private void OnJumpCounterChanged(int value)
    {
        _text.text = value.ToString();
    }
    
    private void OnDestroy()
    {
        _jumpCounter.Changed -= OnJumpCounterChanged;
    }
}
