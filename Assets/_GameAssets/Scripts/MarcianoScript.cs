using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcianoScript : MonoBehaviour {
    [SerializeField] LayerMask floorLayer;
    bool haciaDerecha = true;
    [SerializeField] Transform posPies;
    [SerializeField] Text txtPuntuacion;
    [SerializeField] Text txtPuntuacionVida;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 1;
    int vidasMaximas = 3;
    [SerializeField] int vidas;
    [SerializeField] int vidaMax=100;
    [SerializeField] int puntos = 0;
    [SerializeField] float radioOverlap = 0.1f;
    [SerializeField] Animator playerAnimator;
    Rigidbody2D rb2D;
    bool saltando = false;
    
    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        txtPuntuacion.text = "Score:" + puntos.ToString();
        txtPuntuacionVida.text = "Vida:" + vidaMax.ToString();

    }

    private bool EstaEnElSuelo() {
        bool enSuelo = false;
        Collider2D col = Physics2D.OverlapCircle(posPies.position, radioOverlap, floorLayer);
        if (col != null) {
            enSuelo = true;
        }
        return enSuelo;
    }


    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            saltando = true;
        }
    }
    void FixedUpdate () {
        
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        float ySpeedActual = rb2D.velocity.y;

        if (Mathf.Abs(xPos) > 0.01f) {
            playerAnimator.SetBool("Andar", true);
           
           
        }
        
        
        else {
            playerAnimator.SetBool("Andar", false);
            
           

        }


       // if (Mathf.Abs(xPos) > 0.01f ){
            print("POR AQUI");
            if(saltando) {
                saltando = false;
                if (EstaEnElSuelo()) {
                    rb2D.velocity = new Vector2(xPos * speed, jumpForce);
                } else {
                    rb2D.velocity = new Vector2(xPos * speed, ySpeedActual);
                }
            } else if (Mathf.Abs(xPos) > 0.01f) {
                rb2D.velocity = new Vector2(xPos * speed, ySpeedActual);
            }
       // }
        
    }
  

    public void IncrementarPuntuacion(int puntosAIncrementar) {
        puntos = puntos + puntosAIncrementar;
        txtPuntuacion.text = "Score:" + puntos.ToString();
    }
    public void QuitarVida(int VidaAQuitar) {
        vidaMax = vidaMax - VidaAQuitar;
        txtPuntuacionVida.text = "Vida:" + vidaMax.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Moneda")) {
            IncrementarPuntuacion(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Pinchos")) {
            QuitarVida(5);

            
        }
    }
    
        
    
}
