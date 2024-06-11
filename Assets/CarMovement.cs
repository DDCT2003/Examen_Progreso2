using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento normal
    public float turboSpeed = 10f; // Velocidad de turbo
    public float rotationSpeed = 100f; // Velocidad de rotación
    public float turboDuration = 1f; // Duración del turbo
    public float turboCooldown = 5f; // Tiempo de reutilización del turbo
    private Rigidbody rb;
    private bool isTurboAvailable = true; // Indica si el turbo está disponible
    private float lastTurboTime; // Tiempo en el que se usó el último turbo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtén el Rigidbody adjunto
        lastTurboTime = -turboCooldown; // Inicializa el tiempo del último turbo para permitir el primer uso
    }

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");

        // Verifica si se presiona la tecla de turbo (espacio) y el turbo está disponible
        if (Input.GetKeyDown(KeyCode.Space) && isTurboAvailable)
        {
            isTurboAvailable = false; // Desactiva el turbo hasta que se recargue
            lastTurboTime = Time.time; // Registra el tiempo de uso del turbo
            Invoke("ResetTurboAvailability", turboCooldown); // Resetea la disponibilidad del turbo después del cooldown
            rb.velocity = transform.forward * turboSpeed; // Aplica velocidad de turbo
            Invoke("ResetVelocity", turboDuration); // Resetea la velocidad después de la duración del turbo
        }

        // Movimiento solo cuando se presionan las teclas de movimiento
        if (moveVertical != 0f)
        {
            rb.velocity = transform.forward * moveVertical * moveSpeed;
        }
        else if (!isTurboAvailable)
        {
            rb.velocity = transform.forward * turboSpeed; // Mantiene la velocidad de turbo mientras el turbo esté activo
        }

        // Rotación
        float rotateHorizontal = Input.GetAxis("Horizontal");
        if (rotateHorizontal != 0f)
        {
            Quaternion rotation = Quaternion.Euler(0f, rotateHorizontal * rotationSpeed * Time.deltaTime, 0f);
            rb.MoveRotation(rb.rotation * rotation);
        }
    }

    // Función para resetear la disponibilidad del turbo después del cooldown
    void ResetTurboAvailability()
    {
        isTurboAvailable = true;
    }

    // Función para resetear la velocidad después de la duración del turbo
    void ResetVelocity()
    {
        rb.velocity = transform.forward * moveSpeed;
    }
}
