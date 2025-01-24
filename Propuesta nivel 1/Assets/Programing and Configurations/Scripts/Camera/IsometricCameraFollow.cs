using System.Collections;
using UnityEngine;

public class IsometricCameraFollow : MonoBehaviour
{
    // Instancia Singleton
    public static IsometricCameraFollow Instance { get; private set; }

    [Header("Jugador a seguir")]
    public Transform player;

    [Header("Configuraci�n de la c�mara")]
    public Vector3 offset = new Vector3(-10, 10, -10); // Ajusta para lograr la perspectiva isom�trica
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento

    // Objeto temporal para enfocar
    private Transform temporaryTarget = null;
    private bool isFocusing = false;

    private Vector3 originalPosition; // Posici�n original para el Camera Shake

    private void Awake()
    {
        // Configurar Singleton
        if (Instance != null && Instance != this) {
            Debug.LogWarning("M�s de una instancia de IsometricCameraFollow encontrada. Destruyendo la nueva instancia.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
       // DontDestroyOnLoad(gameObject); // Opcional: Haz que la c�mara persista entre escenas
    }

    private void LateUpdate()
    {
        if (isFocusing) {
            // Si la c�mara est� enfocando temporalmente a otro objeto
            FollowTarget(temporaryTarget);
        } else {
            // Si no, sigue al jugador
            FollowTarget(player);
        }
    }

    /// <summary>
    /// M�todo para seguir un objetivo con suavizado.
    /// </summary>
    /// <param name="target">El objetivo a seguir.</param>
    private void FollowTarget(Transform target)
    {
        if (target == null) {
            Debug.LogWarning("El objetivo de la c�mara no est� asignado.");
            return;
        }

        // Posici�n deseada basada en la posici�n del objetivo y el offset
        Vector3 desiredPosition = target.position + offset;

        // Interpolaci�n para suavizar el movimiento de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualiza la posici�n de la c�mara
        transform.position = smoothedPosition;

        // Asegura que la c�mara mantenga una rotaci�n fija
        transform.rotation = Quaternion.Euler(30, 45, 0); // Ajusta los valores seg�n el �ngulo que desees
    }

    /// <summary>
    /// Cambia temporalmente el enfoque de la c�mara a otro objeto.
    /// </summary>
    /// <param name="target">El nuevo objetivo a enfocar.</param>
    /// <param name="duration">La duraci�n del enfoque en segundos.</param>
    public void FocusOn(Transform target, float duration)
    {
        if (target == null) {
            Debug.LogWarning("El objetivo temporal para enfocar no est� asignado.");
            return;
        }

        StartCoroutine(FocusCoroutine(target, duration));
    }

    /// <summary>
    /// Corrutina para manejar el cambio temporal de enfoque.
    /// </summary>
    private IEnumerator FocusCoroutine(Transform target, float duration)
    {
        temporaryTarget = target;
        isFocusing = true;

        // Espera el tiempo especificado
        yield return new WaitForSeconds(duration);

        // Vuelve a enfocar al jugador
        temporaryTarget = null;
        isFocusing = false;
    }

    /// <summary>
    /// Realiza un Camera Shake durante un tiempo definido.
    /// </summary>
    /// <param name="duration">Duraci�n del shake en segundos.</param>
    /// <param name="magnitude">Magnitud del shake (intensidad).</param>
    public void CameraShake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    /// <summary>
    /// Corrutina para manejar el Camera Shake.
    /// </summary>
    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        originalPosition = transform.position; // Guarda la posici�n original
        float elapsed = 0f;

        while (elapsed < duration) {
            // Genera un peque�o desplazamiento aleatorio dentro de la magnitud
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            // Aplica el desplazamiento
            transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);

            // Incrementa el tiempo transcurrido
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Vuelve a la posici�n original
        transform.position = originalPosition;
    }
}
