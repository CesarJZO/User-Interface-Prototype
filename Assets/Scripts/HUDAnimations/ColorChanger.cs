using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HUDAnimations
{
    /// <summary>Class <c>ColorChanger</c> takes the  UI GameObject (<c>Image</c>)
    /// attached to this script and interpolates randomly its color.</summary>
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] float _duration = 1;
        [SerializeField] Color _finalColor;
        Color _initialColor;
        Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _initialColor = _image.color;
            _finalColor = Color.red;
        }

        /// <summary>Starts a coroutine that interpolates between two colors
        /// <param name="duration">The duration of the effect in seconds</param>
        /// </summary>
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
                float random = Random.Range(0f, 1f);
                _image.color = Color.Lerp(_initialColor, _finalColor, random);
                elapsed += Time.deltaTime;
                yield return 0;
            }
            _image.color = _initialColor;
        }
    }
}
