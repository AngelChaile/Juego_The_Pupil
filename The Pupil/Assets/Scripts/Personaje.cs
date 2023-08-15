using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float fuerzaVertical = 500f;
    [SerializeField] private Transform puntoDeInicio; // Referencia al punto de inicio
    [SerializeField] private float limitXMin = -10f; // Reemplaza estos valores con tus límites
    [SerializeField] private float limitXMax = 10f;
    [SerializeField] private float limitYMin = -10f;
    [SerializeField] private float limitYMax = 10f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    private bool juegoPerdido = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>(); // Quita el espacio en blanco entre GetComponentInChildren y el ()
    }

    void Update()
    {
        if (!juegoPerdido)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(moveX, moveY).normalized;

            playerAnimator.SetFloat("Horizontal", moveX);
            playerAnimator.SetFloat("Vertical", moveY);
            playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
        }
    }

    private void FixedUpdate()
    {
        if (!juegoPerdido)
        {
            playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
        }

        // Verificar si el personaje está fuera de los límites
        if (transform.position.x < limitXMin || transform.position.x > limitXMax ||
            transform.position.y < limitYMin || transform.position.y > limitYMax)
        {
            // Reposicionar al punto de inicio
            transform.position = puntoDeInicio.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Auto") && !juegoPerdido)
        {
            juegoPerdido = true;

            // Aplicar rotación al personaje
            transform.Rotate(Vector3.forward, 90f);

            // Aplicar fuerza vertical para volar
            playerRb.AddForce(Vector2.up * fuerzaVertical);

            // Aquí puedes activar una pantalla de derrota y opciones para reiniciar o salir
        }
    }
}
