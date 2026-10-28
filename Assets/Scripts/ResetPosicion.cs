using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPosicion : MonoBehaviour
{
    public Vector3 posicionInicial;
    Quaternion rotacionInicial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    public void Reiniciar()
    {
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }

    public void OnReset(InputValue value)
    {
        if (value.isPressed)
        {
            Reiniciar();
        }
    }
}