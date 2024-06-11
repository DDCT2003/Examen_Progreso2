using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public float jumpForce = 5f; // Fuerza del salto
    public float jumpInterval = 2f; // Intervalo entre saltos
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtén el Rigidbody adjunto
        InvokeRepeating("Jump", 0f, jumpInterval); // Repite el salto a intervalos regulares
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Verifica si el cubo está en el suelo
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}

