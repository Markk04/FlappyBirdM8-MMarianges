using System.Collections;
using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    public Sprite daySprite;
    public Sprite nightSprite;
    public float switchInterval = 7.0f;
    public float fadeDuration = 2.0f; // Duración del fade en segundos

    private SpriteRenderer spriteRenderer;
    private bool isDay;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer found on the GameObject.");
            return;
        }
        isDay = false;
        spriteRenderer.sprite = daySprite; // Inicialmente mostrar el sprite de día
        StartCoroutine(SwitchBackground());
    }

    IEnumerator SwitchBackground()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchInterval);
            StartCoroutine(FadeBackground());
        }
    }

    IEnumerator FadeBackground()
    {
        float startTime = Time.time;
        Color startColor = spriteRenderer.color;
        Color targetColor = new Color(1, 1, 1, 0); // Transparente

        while (Time.time - startTime < fadeDuration)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / fadeDuration;
            spriteRenderer.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        // Cambiar el sprite
        spriteRenderer.sprite = isDay ? daySprite : nightSprite;

        // Aclarar el fondo
        startTime = Time.time;
        startColor = targetColor; // El color de inicio es ahora transparente
        targetColor = new Color(1, 1, 1, 1); // Opaco

        while (Time.time - startTime < fadeDuration)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / fadeDuration;
            spriteRenderer.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        isDay = !isDay; // Alternar entre día y noche
    }
}
