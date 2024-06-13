using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto del pájaro
    public float maxRotationAngle = 30f; // Ángulo máximo de rotación
    private bool isDead = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isDead && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.X)))
        {
            Flap();
        }
    }

    void FixedUpdate()
    {
        // Ajustar la rotación del jugador según la velocidad vertical
        float rotationZ = Mathf.Clamp(rb.velocity.y * 2f, -maxRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    void Flap()
    {
        // Reiniciar la velocidad para evitar acumulación de fuerza
        rb.velocity = Vector2.zero;

        // Aplicar la fuerza de salto
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            Die();
            MenuManager.Instance.ShowGameOverMenu();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            GameManager.Instance.AddScore(1);
        }
    }

    void Die()
    {
        isDead = true;
        // Implementa lo que necesites cuando el jugador muere, como mostrar un Game Over
    }
}