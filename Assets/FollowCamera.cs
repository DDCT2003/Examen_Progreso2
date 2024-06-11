using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto al que la cámara seguirá
    public Vector3 offset; // La distancia entre la cámara y el objetivo

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("El objetivo no está asignado a la cámara.");
            return;
        }

        // Puedes ajustar el offset inicial en el editor o aquí
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Actualiza la posición de la cámara
        transform.position = target.position + offset;
    }
}
