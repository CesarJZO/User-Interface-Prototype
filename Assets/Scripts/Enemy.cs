using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _angle = 0.5f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -_angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HeroKnight>()?.Hurt();
    }
}
