using UnityEngine;
namespace HUDAnimations
{
    public class Runner : MonoBehaviour
    {
        [SerializeField] float _speed = 5;
        [SerializeField] float _magnitude = 2;
        float _elapsed = 0;
        Vector3 _mover;
        RectTransform _rectTransform;
        void Awake()
        {
            _mover = new Vector2();
            _rectTransform = GetComponent<RectTransform>();
        }
        public void Run()
        {
            _mover.y += Mathf.Sin(_elapsed * _speed) * _magnitude;
            _rectTransform.position += _mover;
            _elapsed += 0.01f;
        }
    }
}
