using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public TextMeshProUGUI lapCounterText; // Referencia al TextMeshProUGUI
    private int lapCount = 0;
    public float cooldownTime = 1.0f; // Tiempo de espera en segundos
    private float lastLapTime = 0; // Última vez que se contó una vuelta

    void Start()
    {
        if (lapCounterText == null)
        {
            Debug.LogError("Lap Counter Text no está asignado en el Inspector.");
            return;
        }

        UpdateLapCounterText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine") && Time.time > lastLapTime + cooldownTime)
        {
            lapCount++;
            lastLapTime = Time.time; // Actualiza el tiempo de la última vuelta
            UpdateLapCounterText();
        }
    }

    void UpdateLapCounterText()
    {
        lapCounterText.text = "Vueltas: " + lapCount.ToString();
    }
}
