using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HUDMover : MonoBehaviour
{
    [SerializeField] float _maxDistance = 1;
    [SerializeField] float _speed = 10;
    [SerializeField] float _magnitude;
    [SerializeField] float _timeToReturn;
    float _duration = 1;
    RectTransform _rectTransform;
    Vector2 _mover;
    Vector2 _positionZero;
    Vector3 _orignalPosition;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mover = new Vector2();
    }
    void Start()
    {
        _orignalPosition = transform.position;
        _positionZero = _rectTransform.position;
    }

    void Update()
    {
        Vector2 direction = HeroKnight.Direction;
        // if (Vector2.Distance(_positionZero, direction + _positionZero) < _maxDistance &&
        //     Vector2.zero != direction)
            transform.Translate(-direction);
        // ! Delete this
        if (Gamepad.current.buttonNorth.wasPressedThisFrame)
            transform.LeanMove(_positionZero, _timeToReturn).setEaseOutBack();
    }

    public void Run(bool isRunning)
    {
        // if (isRunning)
        // {
        //     _mover = _positionZero;
        //     _mover.y = _positionZero.y + Mathf.Sin(Time.time * _speed) * _magnitude;
        //     _rectTransform.position = _mover;
        // }
        // else
        //     transform.LeanMove(_orignalPosition, _timeToReturn/2).setEaseOutBack();
    }

    public void Shake(float duration)
    {
        _duration = duration;
        // StartCoroutine(Shake());
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
        transform.LeanMove(_orignalPosition, _timeToReturn).setEaseOutBack();
    }
}
