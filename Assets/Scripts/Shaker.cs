using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] float _magnitude;
    [SerializeField] float _timeToReturn;
    float _duration = 1;
    Vector2 _mover;
    Vector3 _orignalPosition;

    void Awake()
    {
        _mover = new Vector2();
    }
    void Start()
    {
        _orignalPosition = transform.position;
    }

    public void Shake(float duration)
    {
        this._duration = duration;
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
        transform.LeanMove(_orignalPosition, _timeToReturn).setEaseOutBack();
    }
}
