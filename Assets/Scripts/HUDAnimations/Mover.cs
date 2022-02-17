using System.Collections;
using UnityEngine;

namespace HUDAnimations
{
    /// <summary> Class <c>Mover</c> takes the UI GameObject attached for moving animations
    /// </summary>
    public class Mover : MonoBehaviour
    {
        [SerializeField] RectTransform _centerReference;
        [SerializeField, Range(0f, 0.1f)] float _smoothTime = 0.1f;
        [SerializeField, Range(0f, 5f)] float _magnitude = 2;
        float _duration;
        Vector2 _mover;

        void Awake()
        {
            _mover = new Vector2();
        }

        /// <summary> Makes a follow animation using the target velocity.
        /// If target is not moving, this GameObject returns to its original
        /// position
        /// <param name="velocity">Velocity of the target</param>
        /// </summary>
        public void Follow(Vector3 velocity)
        {
            Vector3 target = _centerReference.position - velocity * _magnitude;
            Vector3 zero = Vector3.zero;
            transform.position = Vector3.SmoothDamp(
                transform.position, target, ref zero, _smoothTime);
        }

        /// <summary> Starts a coroutine that makes a Shake animation to this
        /// UI GameObject for a specified time in seconds
        /// <param name="duration">Duration of the effect in seconds</param>
        /// </summary>
        public void Shake(float duration)
        {
            _duration = duration;
            StartCoroutine(Shake());
        }

        IEnumerator Shake()
        {
            float elapsed = 0f;
            while (elapsed < _duration)
            {
                _mover.x = Random.Range(-1f, 1f) * _magnitude * 2;
                _mover.y = Random.Range(-1f, 1f) * _magnitude * 2;
                transform.Translate(_mover);
                elapsed += Time.deltaTime;
                yield return 0;
            }
        }
    }
}