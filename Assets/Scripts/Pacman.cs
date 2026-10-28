using UnityEngine;
using UnityEngine.InputSystem;

public class Pacman : MonoBehaviour
{
    public float velocidad = 5f;

    Rigidbody2D rb;
    Vector2 input;
    Vector2 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void Update()
    {
        direccion = Vector2.zero;
        if (input.x != 0) direccion = new Vector2(Mathf.Sign(input.x), 0);
        else if (input.y != 0) direccion = new Vector2(0, Mathf.Sign(input.y));

        if (direccion != Vector2.zero)
        {
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccion * velocidad;  
    }

    void OnCollisionEnter2D(Collision2D choque)
    {
        Pacman otro = choque.collider.GetComponentInParent<Pacman>();
        if (otro == null) return; 

        Vector2 haciaElOtro = (otro.transform.position - transform.position).normalized;

        bool loEstoyMirando = Vector2.Dot(transform.right, haciaElOtro) > 0.7f;
        bool meDaLaEspalda = Vector2.Dot(otro.transform.right, haciaElOtro) > 0.7f;

        if (loEstoyMirando && meDaLaEspalda)
        {
            otro.GetComponent<ResetPosicion>().Reiniciar();
        }
    }
}