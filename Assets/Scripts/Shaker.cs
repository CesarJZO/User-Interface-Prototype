using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] float magnitude;
    [SerializeField] float duration = 1;
    [SerializeField] float timeToReturn;
    Vector2 mover;
    Vector3 orignalPosition;

    void Awake()
    {
        mover = new Vector2();
    }
    void Start()
    {
        orignalPosition = transform.position;
    }
    IEnumerator Shake()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            mover.x = Random.Range(-1f, 1f) * magnitude;
            mover.y = Random.Range(-1f, 1f) * magnitude;
            transform.Translate(mover);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.LeanMove(orignalPosition, timeToReturn).setEaseOutBack();
    }
}
