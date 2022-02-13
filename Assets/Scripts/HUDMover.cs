using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HUDMover : MonoBehaviour
{
    [SerializeField] RectTransform _center;
    [SerializeField] float _maxDistance = 1;
    [SerializeField] float _speed = 10;
    [SerializeField] float _magnitude;
    [SerializeField] float _timeToReturn;
    float _duration = 1;
    Vector2 _mover;

    void Awake()
    {
        _mover = new Vector2();
    }

    void Update()
    {
        Vector3 direction = HeroKnight.Direction;
        transform.position = _center.position + 
            Vector3.ClampMagnitude(-direction, _maxDistance);
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
