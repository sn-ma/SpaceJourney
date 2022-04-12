using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public Gradient gradient;
    public Image fillImage;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetNormalizedValue(float value)
    {
        slider.value = value;
        fillImage.color = gradient.Evaluate(value);
    }
}
