using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField]float speed = 1.0f; //how fast it shakes
    [SerializeField]float amount = 1.0f; //how much it shakes
    RectTransform rectTransform;
    Vector2 mover;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        mover = new Vector2();
    }
    void Update()
    {
        mover.x = Mathf.Sin(Time.time * speed) * amount;
        mover.y = Mathf.Cos(Time.time * speed) * amount;
        rectTransform.Translate(mover);
        //rectTransform.LeanSetPosY(y);
    }
}
