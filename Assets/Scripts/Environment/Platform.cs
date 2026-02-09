using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float fadeDuration = 0.7f;
    private SpriteRenderer[] renderers;
    private Collider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Platform Spawned");
        renderers = GetComponentsInChildren<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        StartCoroutine(LifeCycle(8f));

        // SetAlpha(0f);

        // Fade(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LifeCycle(float lifetime)
    {
        Debug.Log("Running platform script");

        SetAlpha(0f);

        // Fade in
        yield return StartCoroutine(Fade(0, 1));

        // Wait
        yield return new WaitForSeconds(lifetime);

        // Fade out
        yield return StartCoroutine(Fade(1, 0));

        DestroySelf();
    }

    IEnumerator Fade(float start, float end)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            // Tween the transparency
            float alpha = Mathf.Lerp(start, end, timer / fadeDuration);

            SetAlpha(alpha);

            // Wait a frame
            yield return null;
        }

        SetAlpha(end);
    }

    void SetAlpha(float alpha)
    {
        foreach (var renderer in renderers)
        {
            Color c = renderer.color;
            c.a = alpha;
            renderer.color = c;
        }
    }
       
    // Code to destroy platform after certain duration
    public void SetTimer(float duration)
    {
        Invoke(nameof(DestroySelf), duration);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
