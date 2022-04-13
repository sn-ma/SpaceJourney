using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float fadeInSpeed = 1f;
    public float delayTimeSec = 0.5f;
    public float fadeOutSpeed = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color initialColor;

    private Coroutine coroutine = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.material.color;

        SetAlpha(0f);
    }

    public void StartFadeAnimation()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(FadeAnimationObject());
    }

    public IEnumerator FadeAnimationObject()
    {
        while (spriteRenderer.material.color.a < 1f)
        {
            SetAlpha(GetAlpha() + fadeInSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(delayTimeSec);

        while (spriteRenderer.material.color.a > 0f)
        {
            SetAlpha(GetAlpha() - fadeOutSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private float GetAlpha()
    {
        return spriteRenderer.material.color.a;
    }

    private void SetAlpha(float alpha)
    {
        spriteRenderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
    }
}
