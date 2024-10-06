using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    private Image image;
    private float elapsedTime;
    private float alpha;
    [SerializeField]private float fadeDuration;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        IndexMusic.eventFade += FadeIn;
    }
    private void OnDisable()
    {
        IndexMusic.eventFade -= FadeIn;
    }
    public void FadeIn()
    {
        StartCoroutine(FadeImage(0f, 1f));
    }
    public void FadeOut()
    {
        StartCoroutine(FadeImage(1f, 0f));
    }
    private IEnumerator FadeImage(float startAlpha, float endAlpha)
    {
        Color color = image.color;
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            image.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        if (alpha == 1)
        {
            FadeOut();
        }
    }
}
