using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject Arma;
    public GameObject Player;
    public int municao;
    public int max_municao;
    public Text municaoTxt;
    public int vida;
    public Text vidaTxt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        municao = Arma.GetComponent<Arma>().municao;
        max_municao = Arma.GetComponent<Arma>().max_municao;
        vida = Player.GetComponent<Player>().vida;

        municaoTxt.text = municao.ToString() + "/" + max_municao.ToString();
        vidaTxt.text = vida.ToString();

    }
}
