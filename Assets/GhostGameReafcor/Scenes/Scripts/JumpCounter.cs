using System;

public class JumpCounter
{
    public event Action<int> Changed;
    private IJumper _jumper;
    private int _count;

    public JumpCounter(IJumper jumper)
    {
        _jumper = jumper;
        _jumper.Jumped += OnJumped;
    }

    public int Count
    {
        get => _count;
        private set
        {
            _count = value;
           Changed?.Invoke(_count);
        }
    }

    public void Deinitialize()
    {
        _jumper.Jumped -= OnJumped;
    }

    public void Clear() => Count = 0;
    private void OnJumped() => _count++;
    
    
}
