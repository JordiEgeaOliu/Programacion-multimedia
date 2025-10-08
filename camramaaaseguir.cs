using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Objeto a seguir")]
    public Transform target; // El personaje

    [Header("Ajustes de cámara")]
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset;             // Desplazamiento de la cámara respecto al jugador

    void LateUpdate()
    {
        if (target != null)
        {
            // Posición deseada = posición del jugador + offset
            Vector3 desiredPosition = target.position + offset;

            // Suaviza el movimiento de la cámara hacia esa posición
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
