using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public GameObject optionsPanel;

    public void ButtonPlay()
    {
        SceneManager.LoadScene(cena);
    }
 
    public void ButtonQuit()
    {
        //unity editor
        UnityEditor.EditorApplication.isPlaying = false;
        //Game Completed
        //Application.Quit(); 
        //QUANDO COMPILAR O JOGO, FAVOR COMENTAR A LINHA 19 (UNITY EDITOR)
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
    }
}
