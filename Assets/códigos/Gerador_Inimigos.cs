using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador_Inimigos : MonoBehaviour {
    
    [SerializeField] private GameObject inimigo;
    private float momentoDaUltimaGeracao;
    private int numInimigos = 0;

    [Range(0,3)]
    [SerializeField] private float tempoDeCriacao = 2f;

    void Update () {
        
        GeraInimigo ();
    }
    private void GeraInimigo () {

        float tempoAtual = Time.time;
        if (tempoAtual > momentoDaUltimaGeracao + tempoDeCriacao && numInimigos < 30){

            momentoDaUltimaGeracao = tempoAtual;
            Vector3 posicaoDoGerador = this.transform.position;
            Instantiate (inimigo, posicaoDoGerador,Quaternion.identity);
            numInimigos++;

        }
    }
}
