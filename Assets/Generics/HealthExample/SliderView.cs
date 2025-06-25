using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private IReadOnlyVariable<float> _current;
    private IReadOnlyVariable<float> _max;



    public void Initialize(IReadOnlyVariable<float> current, IReadOnlyVariable<float> max)
    {
        _current = current;
        _max = max;

        _current.Changed += OnCurrentChanged;
        _max.Changed += OnMaxChange;

        UpdateValue(_current.Value, _max.Value);
    }


    private void OnDestroy()
    {
        _current.Changed -= OnCurrentChanged;
        _max.Changed -= OnMaxChange;
    }
    private void OnMaxChange(float arg1, float newValue) => UpdateValue(_current.Value, newValue);
    

    private void OnCurrentChanged(float arg1, float newValue) => UpdateValue(newValue,_max.Value);

    private void UpdateValue(float currentValue , float maxValue) => _slider.value = currentValue / maxValue;
}