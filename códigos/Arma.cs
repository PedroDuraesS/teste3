using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    [Header("Configuração da Arma")]

    public float dano;
    public float tps;
    public int municao;
    public int max_municao;
    public float tempo_recarregar = 2;
    float deltaUltimoTiro;

    [HideInInspector]
    public bool recarregando = false;
    private bool podeAtirar() => recarregando == false && deltaUltimoTiro > 1f / (tps/60f) && municao > 0;

    [SerializeField] public GameObject prefabTiro;
    [SerializeField] public GameObject pontoDisparo;

    [Header("Mapeamento de teclas")]
    [SerializeField] private KeyCode recarregar;

    public void atirar(){

        if(podeAtirar()){

            municao--;
            deltaUltimoTiro = 0;

        }

    }

    private IEnumerator recarrega(){

        recarregando = true;
        print("recarregando");

        yield return new WaitForSeconds(tempo_recarregar);

        municao = max_municao;

        recarregando = false;

    }
    void Update(){

        deltaUltimoTiro += Time.deltaTime;

        if(Input.GetMouseButton(0)){
            atirar();
        }

        if(Input.GetKeyDown(recarregar)){
            if(recarregando == false)
                StartCoroutine(recarrega());
        }

    }
}
