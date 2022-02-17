using UnityEngine;
namespace HUDAnimations
{
    /// <summary> Class <c>Runner</c> Takes the full canvas using an empty
    /// <c>GameObject</c> or an individual <c>GameObject</c> and moves it
    /// up and down based on the state of a reference
    /// </summary>
    public class Runner : MonoBehaviour
    {
        [SerializeField] RectTransform _centerReference;
        [SerializeField] float _speed = 5;
        [SerializeField] float _magnitude = 2;
        Vector3 _direction;
        RectTransform _rectTransform;
        void Awake()
        {
            _direction = new Vector2();
            _rectTransform = GetComponent<RectTransform>();
        }
        /// <summary> Run makes the specified GameObject move up and down
        /// using its RectTransform component
        /// <param name="isRunning">Wether is running or idle</param>
        /// </summary>
        public void Run(bool isRunning)
        {
            if (isRunning)
            { // Moves UI up and down
                _direction.x = _rectTransform.position.x;
                _direction.y = _rectTransform.position.y + Mathf.Sin(Time.time * _speed) * _magnitude;
                _rectTransform.position = _direction;
            }
            else
            { // Returns to center
                Vector3 zero = Vector3.zero;
                _rectTransform.position = Vector3.SmoothDamp(
                    _rectTransform.position, _centerReference.position, ref zero, 0.1f);
            }
        }
    }
}
