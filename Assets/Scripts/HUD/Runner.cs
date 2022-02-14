using UnityEngine;
namespace HUDAnimations
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] RectTransform _centerReference;
        [SerializeField] Mover _moverScript;
        [SerializeField] float _speed = 5;
        [SerializeField] float _magnitude = 2;
        float _elapsed = 0;
        Vector3 _direction;
        RectTransform _rectTransform;
        void Awake()
        {
            _direction = new Vector2();
            _rectTransform = GetComponent<RectTransform>();
        }
        public void Run(bool isRunning)
        {
            if (isRunning)
            {
                _direction.x = _rectTransform.position.x;
                _direction.y = _rectTransform.position.y + Mathf.Sin(Time.time * _speed) * _magnitude;
                _rectTransform.position = _direction;
                _elapsed += 0.01f;
            }
            else
            {
                Vector3 zero = Vector3.zero;
                _rectTransform.position = Vector3.SmoothDamp(
                    _rectTransform.position, _centerReference.position, ref zero, 0.1f);
            }
        }
    }
}
