using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    
    [SerializeField] private int vida = 100;

    public void RecebeDano(int Dano) {

        vida -= Dano;

        if (vida <= 0) {

            Destroy(this.gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        UnityEngine.AI.NavMeshAgent inimigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GameObject fim = GameObject.Find("Player");
        Vector3 coordenada_fim = fim.transform.position;

        inimigo.SetDestination(coordenada_fim);

    }
}
