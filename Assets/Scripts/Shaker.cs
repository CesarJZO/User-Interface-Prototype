using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] HeroKnight player;
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
        player.OnPlayerHit += Knight_OnPlayerHit;
        orignalPosition = transform.position;
    }

    private void Knight_OnPlayerHit(object sender, System.EventArgs e)
    {
        StartCoroutine("Shake");
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
