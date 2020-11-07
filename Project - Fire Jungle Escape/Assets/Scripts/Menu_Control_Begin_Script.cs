using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Control_Begin_Script : MonoBehaviour
{
    GameObject Creditos;
    // Start is called before the first frame update
    void Start()
    {       
        Time.timeScale = 1;
        Creditos = GameObject.Find("Creditos");
        Creditos.SetActive(false);
    }

    public void Button_Voltar()
    {
        Creditos.SetActive(false);
    }
    public void Button_Creditos()
    {
        Creditos.SetActive(true);
    }
    public void Button_Jogar()
    {
        SceneManager.LoadScene("Game_Scene");
    }
    public void Button_Sair()
    {
        Application.Quit();
    }
}
