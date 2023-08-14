using UnityEngine;

public class LimitadorMovimiento : MonoBehaviour
{
    public float maximoX;
    public float minimoX;
    public float maximoY;
    public float minimoY;

    private void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minimoX, maximoX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minimoY, maximoY);
        transform.position = clampedPosition;
    }
}
