using UnityEngine;

public class Health 
{
    private ReactiveVariable<float> _current;
    private ReactiveVariable<float> _max;

    public Health(float current, float max)
    {
        _current = new ReactiveVariable<float>(current); 
        _max = new ReactiveVariable<float>(max); ;
    }


    //Сделаем защиту при разговоре об инкапсуляции;

    public new IReadOnlyVariable<float> Max => _max;
    public new IReadOnlyVariable<float> Current => _current;
    

    public void Reduce(float value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        _current.Value = Mathf.Clamp(_current.Value - value, 0, _max.Value);
    }
    
    public void Add(float value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }


        _current.Value = Mathf.Clamp(_current.Value + value, 0, _max.Value);     
    }

}
