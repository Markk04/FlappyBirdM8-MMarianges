using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento del obstáculo

    void Update()
    {
        // Mover el obstáculo hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el obstáculo está fuera del área de juego, destruirlo para ahorrar recursos
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con el jugador, terminar el juego
        // Por ejemplo, puedes reiniciar la escena aquí
        // O mostrar un menú de Game Over
    }
}
