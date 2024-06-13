using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public float spawnRate = 5f; // Tasa de generación de obstáculos (en segundos)
    public float spawnHeightRange = 4f; // Rango de altura de generación de obstáculos
    private float nextSpawnTime;

    void Start()
    {
        // Generar el primer obstáculo al iniciar el juego
        SpawnObstacle();
        // Calcular el tiempo para el próximo obstáculo
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        // Verificar si es el momento de generar un nuevo obstáculo
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            // Calcular el tiempo para el próximo obstáculo
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObstacle()
    {
        // Calcular una posición vertical aleatoria para el obstáculo dentro del rango definido
        float spawnPosY = Random.Range(-spawnHeightRange, spawnHeightRange);
        // Generar un nuevo obstáculo en la posición del spawner con la posición vertical aleatoria
        Instantiate(obstaclePrefab, new Vector3(transform.position.x, spawnPosY, 0), Quaternion.identity);
    }
}
