using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDebrisManager : MonoBehaviour
{
    public GameObject[] debrisPrefabs; // Array de prefabs de basura espacial
    public float spawnInterval = 2f; // Intervalo de generación
    public float spawnYMin = -4f; // Mínima posición Y
    public float spawnYMax = 4f; // Máxima posición Y
    public float speed = 5f; // Velocidad de desplazamiento

    void Start()
    {
        StartCoroutine(SpawnDebris());
    }

    IEnumerator SpawnDebris()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnDebrisInstance();
        }
    }

    void SpawnDebrisInstance()
    {
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPosition = new Vector3(320, spawnY, 0); // Ajusta la posición X según tu pantalla
        GameObject debris = Instantiate(debrisPrefabs[Random.Range(0, debrisPrefabs.Length)], spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360))); // Rotación aleatoria
        debris.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-speed, 0); // Desplaza a la izquierda
    }
}