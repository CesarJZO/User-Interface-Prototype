using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ColorChanger : MonoBehaviour
{
    float _duration = 1;
    Color _initialColor;
    Color _finalColor;
    Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _initialColor = _image.color;
        _finalColor = Color.red;
    }

    public void InterpolateColor(float duration)
    {
        _duration = duration;
        StartCoroutine(InterpolateColor());
    }

    IEnumerator InterpolateColor()
    {
        float elapsed = 0f;
        while (elapsed < _duration)
        {
            float num = Random.Range(0f, 1f);
            _image.color = Color.Lerp(_initialColor, _finalColor, num);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        _image.color = _initialColor;
    }
}
