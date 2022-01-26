using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float angle = 0.5f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ouch!");
        collision.gameObject.GetComponent<HeroKnight>()?.Hurt();
    }
}
