using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del auto
    public float maxX = 5f; // Límite máximo en el eje X
    public float minX = -5f; // Límite mínimo en el eje X
    private int direction = 1; // Dirección inicial del auto (1: derecha, -1: izquierda)

    void Update()
    {
        // Calcula el desplazamiento del auto en el eje X
        float movement = speed * Time.deltaTime * direction;
        // Actualiza la posición del auto
        transform.Translate(new Vector2(movement, 0));

        // Si el auto llega al límite derecho o izquierdo, cambia la dirección
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            direction *= -1; // Cambiar la dirección
        }
    }
}
