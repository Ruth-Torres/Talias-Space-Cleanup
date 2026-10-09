using UnityEngine;
using System.Collections;

public class Satelite2Capture : MonoBehaviour
{
    private GameObject mensaje1_0;
    private AudioSource appearSound;

    void Start()
    {
        // Encuentra el GameObject "mensaje1_0" incluso si está desactivado
        mensaje1_0 = FindInactiveObjectByName("mensaje1_0");

        if (mensaje1_0 == null)
        {
            Debug.LogError("No se encontró el GameObject 'mensaje1_0' en la escena.");
        }
        else
        {
            Debug.Log("GameObject 'mensaje1_0' encontrado.");
            // Obtener el componente AudioSource
            appearSound = mensaje1_0.GetComponent<AudioSource>();
            if (appearSound == null)
            {
                Debug.LogError("No se encontró el componente AudioSource en 'mensaje1_0'.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.name);
        if (other.CompareTag("Player"))
        {
            if (mensaje1_0 != null)
            {
                Debug.Log("Mostrando mensaje.");
                // Activa el GameObject
                mensaje1_0.SetActive(true);
                // Reproducir el sonido de aparición
                if (appearSound != null)
                {
                    appearSound.Play();
                }
            }
        }
    }

    // Este método será llamado al final de la animación
    public void OnAnimationEnd()
    {
        Debug.Log("Ocultando mensaje al finalizar la animación.");
        if (mensaje1_0 != null)
        {
            mensaje1_0.SetActive(false);
        }
    }

    GameObject FindInactiveObjectByName(string name)
    {
        GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>(); // Incluye objetos inactivos
        foreach (GameObject obj in objs)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }
}