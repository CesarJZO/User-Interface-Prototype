using System.Collections;
using UnityEngine;

public class HUDMover : MonoBehaviour
{
    [SerializeField] RectTransform _center;
    [SerializeField] float _smoothTime = 0.1f;
    [SerializeField] float _speed = 500;
    [SerializeField] float _magnitude = 10;
    [SerializeField] float _timeToReturn = 1;
    float _duration;
    Vector2 _mover;

    void Awake()
    {
        _mover = new Vector2();
    }

    public void Follow(Vector3 velocity)
    {
        Vector3 target = _center.position - velocity;
        Vector3 zero = Vector3.zero;
        transform.position = Vector3.SmoothDamp(
            transform.position, target, ref zero, _smoothTime);
    }

    public void Run(bool isRunning)
    {
        // if (isRunning)
        // {
        //     _mover = _center.position;
        //     _mover.y = _center.position.y + Mathf.Sin(Time.time * _speed) * _magnitude;
        //     transform.position = _mover;
        // }
        // else
        //     transform.LeanMove(_center.position, _timeToReturn/2).setEaseOutBack();
    }

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
            _mover.x = Random.Range(-1f, 1f) * _magnitude;
            _mover.y = Random.Range(-1f, 1f) * _magnitude;
            transform.Translate(_mover);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.LeanMove(_center.position, _timeToReturn).setEaseOutBack();
    }
}
