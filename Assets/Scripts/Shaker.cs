using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] float magnitude;
    [SerializeField] float duration;
    RectTransform rectTransform;
    Vector2 mover;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        mover = new Vector2();
    }
    public IEnumerator Shake()
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        Debug.Log("Vértigo, papá");
        while (elapsed < duration)
        {
            mover.x = Random.Range(-1f, 1f) * magnitude;
            mover.y = Random.Range(-1f, 1f) * magnitude;

            transform.Translate(mover);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
