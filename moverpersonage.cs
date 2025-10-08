using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    [Header("Salto")]
    public float fuerzaSalto = 7f;
    public int saltosMaximos = 2; // Número máximo de saltos (2 = doble salto)

    private Rigidbody2D rb;
    private int saltosRestantes;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosRestantes = saltosMaximos; // Al empezar, tiene todos los saltos
    }

    void Update()
    {
        // Movimiento horizontal
        float movimiento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Volteo del sprite
        if (movimiento > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimiento < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Salto (permite doble)
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Resetea velocidad vertical
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltosRestantes--; // Consume un salto
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        // Si el contacto es con el suelo
        if (colision.contacts[0].normal.y > 0.5f)
        {
            saltosRestantes = saltosMaximos; // Se reinician los saltos al tocar el suelo
        }
    }
}