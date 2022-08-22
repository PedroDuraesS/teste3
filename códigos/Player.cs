using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Dados")]

    public int vida = 100;

	[Header("Movement")]

    public float velocidade = 6f;
    public float aceleracao = 10f;
    public float rbAtrito = 6f;
    public Transform orientacao;
    float movimento_horizontal;
    float movimento_vertical;
    Vector3 direcao;
    Rigidbody rb;
    [SerializeField] private KeyCode Correr;

    private void Start(){

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update(){

        Entrada_dados();
        Atrito();

    }


    void Entrada_dados(){

        movimento_horizontal = Input.GetAxisRaw("Horizontal");
        movimento_vertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate(){

        movimentacao();
        
        if(Input.GetKey(Correr))
        {
            velocidade = 50f;
        }
        else
        {
            velocidade = 25f;
        }

    }

    void movimentacao(){

        direcao = orientacao.forward * movimento_vertical + orientacao.right * movimento_horizontal;
        rb.AddForce(direcao.normalized * velocidade * aceleracao, ForceMode.Acceleration);

    }

    void Atrito(){

        rb.drag = rbAtrito;
        

    }

}
