using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float screenLeftEdge;

    void Start()
    {
        // Calcula la posición X del borde izquierdo de la pantalla
        screenLeftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    }

    void Update()
    {
        // Destruye el objeto si su posición X es menor que el borde izquierdo de la pantalla
        if (transform.position.x < screenLeftEdge-50)
        {
            Destroy(gameObject);
        }
    }
}