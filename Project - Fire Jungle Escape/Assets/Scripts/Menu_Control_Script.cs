using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Control_Script : MonoBehaviour
{
    [SerializeField] Text Cronometro_Texto;
    [SerializeField] Text Points_Texto;

    [SerializeField] Image life_Bar;
    [SerializeField] Slider Volume_Control;

    Player_Script Player;
    GameObject Menu_Pause;
    GameObject Menu_Over;
   
    public AudioSource Audio_Control;

    private float StartTime;
    float TimerControl;
    string mins ;
    string segs ;
    string milisegs ;

    void Start()
    {
        StartTime = Time.time;

        Player = GameObject.Find("Player").GetComponent<Player_Script>();

        Volume_Control = GameObject.Find("Slider Volume").GetComponent<Slider>();
        Volume_Control.value = 1;

        Audio_Control = GameObject.Find("Audio Control").GetComponent<AudioSource>();

        Menu_Pause = GameObject.Find("Menu Pause");
        Menu_Pause.SetActive(false);
        
        Menu_Over = GameObject.Find("Menu GameOver");
        Menu_Over.SetActive(false);
        
        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {
        Pause();
        
        Volume();
        Cronometro();
        GameOver();
        Life_Bar_Status();
        Points_Status();
    }
    void Cronometro()
    {
         TimerControl = Time.time - StartTime;
         mins = ((int)TimerControl / 60).ToString("00");
         segs = (TimerControl % 60).ToString("00");
         milisegs = ((TimerControl * 100) % 100).ToString("00");
         Cronometro_Texto.text = string.Format("{00}:{01}:{02}", mins, segs, milisegs);
    }
    void Life_Bar_Status()
    {
        life_Bar.fillAmount = Player.life/100;
        if(Player.life<60&& Player.life > 30)
        {
            life_Bar.color = new Color(1, 1, 0);
        }
        else if (Player.life < 30)
        {
            life_Bar.color = new Color(1, 0, 0);
        }
        else
        {
            life_Bar.color = new Color(0, 1, 0);
        }
    }
    void Points_Status()
    {
    Points_Texto.text=string.Format("Pontos: {0:D5}", Player.points);
    }
    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& Player.life > 0)
        {
            if(Time.timeScale==1)
            {
                Time.timeScale = 0;
                Menu_Pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Menu_Pause.SetActive(false);
            }
        }
    }
    void GameOver()
    {
        if(Player.life<= 0)
        {
            Menu_Over.SetActive(true);
            Time.timeScale = 0;

        }
    }
    void Volume()
    {
        if (Time.timeScale == 0)
        {
            Audio_Control.volume = Volume_Control.value;
        }
    }
    public void Button_Continue()
    {
        Time.timeScale = 1;
        Menu_Pause.SetActive(false);
    }
    public void Button_Novo_Jogo() 
    {
        SceneManager.LoadScene("Game_Scene"); 
    }
    public void Button_Sair() {
        SceneManager.LoadScene("Menu_Inicial");
    }

}
