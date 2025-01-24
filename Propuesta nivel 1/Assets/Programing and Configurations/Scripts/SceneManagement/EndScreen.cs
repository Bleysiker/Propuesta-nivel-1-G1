using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen Instance { get; private set; }

    public CanvasGroup panelCanvasGroup; // El CanvasGroup del panel
    public float fadeDuration = 2.0f;    // Duración de la transición en segundos

    private bool isFadingIn = false;     // Indica si el panel está apareciendo

    private void Awake()
    {
        // Configuración del Singleton
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject); // Eliminar duplicados
        }
    }

    private void Start()
    {
        // Asegúrate de que el panel comience invisible
        if (panelCanvasGroup != null) {
            panelCanvasGroup.alpha = 0f;             // Comienza completamente transparente
            panelCanvasGroup.interactable = false;   // Deshabilita la interacción
            panelCanvasGroup.blocksRaycasts = false; // No bloquea clics
        }
    }

    public void ShowPanel()
    {
        if (!isFadingIn && panelCanvasGroup != null) {
            StartCoroutine(FadeInPanel());
        }
    }

    public void HidePanel()
    {
        if (!isFadingIn && panelCanvasGroup != null) {
            StartCoroutine(FadeOutPanel());
        }
    }

    private IEnumerator FadeInPanel()
    {
        isFadingIn = true;
        float timer = 0f;

        // Activa la interacción del panel
        panelCanvasGroup.interactable = true;
        panelCanvasGroup.blocksRaycasts = true;

        while (timer < fadeDuration) {
            timer += Time.deltaTime;
            panelCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration); // Aumenta gradualmente la opacidad
            yield return null; // Espera al siguiente frame
        }

        panelCanvasGroup.alpha = 1f; // Asegúrate de que la opacidad quede en 1
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
        isFadingIn = false;
    }

    private IEnumerator FadeOutPanel()
    {
        float timer = 0f;

        while (timer < fadeDuration) {
            timer += Time.deltaTime;
            panelCanvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration); // Reduce gradualmente la opacidad
            yield return null; // Espera al siguiente frame
        }

        // Desactiva la interacción del panel
        panelCanvasGroup.alpha = 0f;
        panelCanvasGroup.interactable = false;
        panelCanvasGroup.blocksRaycasts = false;
    }
}
