using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Control_Script : MonoBehaviour
{
    [SerializeField] Text Cronometro_Texto;
    private float StartTime;
    float TimerControl;
    string mins ;
    string segs ;
    string milisegs ;

    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Cronometro();
    }
    void Cronometro()
    {
         TimerControl = Time.time - StartTime;
         mins = ((int)TimerControl / 60).ToString("00");
         segs = (TimerControl % 60).ToString("00");
         milisegs = ((TimerControl * 100) % 100).ToString("00");
        Cronometro_Texto.text = string.Format("{00}:{01}:{02}", mins, segs, milisegs);
    }
}
