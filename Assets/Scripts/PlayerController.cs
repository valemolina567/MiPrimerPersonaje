using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadMovimiento = 5f;
    private Rigidbody2D rb2D;
    private Animator animator;
    private float inputHorizontal;
    private bool mirandoDerecha = true; // Para controlar la dirección inicial

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        // Obtener el componente Animator
        animator = GetComponent<Animator>();

        // Verificar que el Rigidbody2D existe
        if(rb2D == null)
        {
            Debug.LogError("¡No se encontró Rigidbody2D en " + gameObject.name + "!");
        }

        if(animator == null)
        {
            Debug.LogError("¡No se encontró Animator en " + gameObject.name + "!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Capturar movimiento usando la velocidad del Rigidbody2D
        inputHorizontal = Input.GetAxis("Horizontal");

        // Hacer flip del personaje según la dirección
        HacerFlip();

        // Actualizar animaciones
        ActualizarAnimaciones();
    }

    void FixedUpdate()
    {
        // Aplicar movimiento usando la velocidad del Rigidbody2D
        if(rb2D != null)
        {
            // Mantener la velocidad Y actual (para conservar la gravedad/saltos)
            Vector2 velocidad = new Vector2(inputHorizontal * velocidadMovimiento, rb2D.linearVelocity.y);
            rb2D.linearVelocity = velocidad;
    
        }
    }

    void HacerFlip()
    {
        // Solo hacer flip si hay movimiento horizontal
        if(inputHorizontal > 0 && !mirandoDerecha)
        {
            // Movimiento a la derecha y mirando a la izquierda -> voltear
            Voltear();
        }
        else if(inputHorizontal < 0 && mirandoDerecha)
        {
            //Moviéndose a la izquierda y mirando a la derecha -> voltear
            Voltear();
        }
    }

    void Voltear()
    {
        // Cambiar la dirección
        mirandoDerecha = !mirandoDerecha;

        // Voltear usando la escala en X del transform
        Vector3 escala = transform.localScale;
        escala.x *= -1f; // Invertir la escala en X
        transform.localScale = escala;
    }

    void ActualizarAnimaciones()
    {
        // Detener si está caminando (hay input horizontal)
        bool estaCaminando = Mathf.Abs(inputHorizontal) > 0.1f;

        // Actualizar el parámetro en el Animator
        animator.SetBool("Estacaminando", estaCaminando);
    }
}
