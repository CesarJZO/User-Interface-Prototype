using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ColorChanger : MonoBehaviour
{
    [SerializeField] HeroKnight player;
    [SerializeField] float duration = 1;
    Color initialColor;
    Color finalColor;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        initialColor = image.color;
        finalColor = Color.red;
    }

    private void Start()
    {
        player.OnPlayerHit += Player_OnPlayerHit;
    }

    private void Player_OnPlayerHit(object sender, System.EventArgs e)
    {
        StartCoroutine("InterpolateColor");
    }

    IEnumerator InterpolateColor()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float num = Random.Range(0f, 1f);
            image.color = Color.Lerp(initialColor, finalColor, num);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        image.color = initialColor;
    }
}
