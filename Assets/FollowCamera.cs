using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // El objeto al que la c�mara seguir�
    public Vector3 offset; // La distancia entre la c�mara y el objetivo

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("El objetivo no est� asignado a la c�mara.");
            return;
        }

        // Puedes ajustar el offset inicial en el editor o aqu�
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Actualiza la posici�n de la c�mara
        transform.position = target.position + offset;
    }
}
