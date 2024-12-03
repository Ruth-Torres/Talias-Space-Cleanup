using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceJunkCounter : MonoBehaviour
{
    public int prefabCount = 0; // Contador de prefabs
    public TextMeshProUGUI counterText; // Referencia al texto UI
    private bool hasCollided = false; // Flag para evitar múltiples incrementos

    void Start()
    {
        // Encuentra el objeto CounterText en la jerarquía y asigna el componente TextMeshProUGUI
        counterText = GameObject.Find("CounterText").GetComponent<TextMeshProUGUI>();
        // Inicializa el texto del contador
        UpdateCounterText();
    }

    // Método para actualizar el texto del contador
    void UpdateCounterText()
    {
        counterText.text = "Basura capturada: " + prefabCount;
    }

    // Método para detectar colisiones
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCollided && other.gameObject.CompareTag("SpaceDebris"))
        {
            hasCollided = true; // Marca que ha habido una colisión
            other.gameObject.SetActive(false); // Desactiva el objeto
            Destroy(other.gameObject); // Destruye el objeto
            prefabCount++; // Incrementa el contador
            UpdateCounterText();
        }
    }

    void LateUpdate()
    {
        hasCollided = false; // Resetea el flag al final de cada frame
    }
}