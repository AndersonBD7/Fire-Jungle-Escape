using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Control_Script : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] Text Cronometro_Texto;
    [SerializeField] Text Score_Texto;
    [SerializeField] Image life_Bar;
    [SerializeField] Slider Volume_Control;
    [Header("Scene Velocity")]
    [SerializeField] float time_Up = 1;
    [SerializeField] float time_Quant = 0.001f;
    [SerializeField] Move_Obj_Script move1;
    [SerializeField] Move_Obj_Script move2;


    Player_Script Player;
    GameObject Menu_Pause;
    GameObject Menu_Over;
   
    public AudioSource Audio_Control;

    private float StartTime;
    float time;
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

        Cronometro_Texto = GameObject.Find("Time Text").GetComponent<Text>();
        Score_Texto = GameObject.Find("Score Text").GetComponent<Text>();

        Menu_Pause = GameObject.Find("Menu Pause");
        Menu_Pause.SetActive(false);
        
        Menu_Over = GameObject.Find("Menu GameOver");
        Menu_Over.SetActive(false);
        

        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {        Pause();
        GameOver();
        if (Time.timeScale == 1)
        {
            VelocidadeUp();
            Volume();
            Cronometro();
            Life_Bar_Status();
            Points_Status();
        }
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
        Score_Texto.text=string.Format("Pontos: {0:D5}", Player.points);
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
    void VelocidadeUp()
    {
        time += Time.deltaTime;
        if (time >= time_Up)
        {
            time = 0;
            move1.Speed += time_Quant;
            move2.Speed += time_Quant;
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
