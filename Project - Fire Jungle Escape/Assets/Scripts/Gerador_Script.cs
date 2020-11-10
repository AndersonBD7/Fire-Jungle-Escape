using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Gerador_Script : MonoBehaviour
{
    [SerializeField] float time = 0, time_gerador = 0, n_obstaculos = 0;
    [SerializeField] GameObject life;
    [SerializeField] GameObject[] Obstaculos_Gerados = new GameObject[1];
    [SerializeField] Vector2 G_Min_max = new Vector2(1, 3);
    int obstaculo = 0;
    Obstacles_Script aux_obstaculo;
    [SerializeField] float time_Up = 5;
    [SerializeField] float time_Quant = 0.1f;
    Player_Script Player;
    float time2 = 0;
    [HideInInspector] public bool life_create = true;
    Vector3 life_pos = new Vector3(0, 1.5f, 200);
    void Start()
    {
        time_gerador = Random.Range(1, 5);
        n_obstaculos = Obstaculos_Gerados.Length;
        Player = GameObject.Find("Player").GetComponent<Player_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Gerar_Obstaculo(); Gerar_Vida();
        }
    }
    void Gerar_Obstaculo()
    {
        time += Time.deltaTime;
        if (time >= time_gerador)
        {
            time = 0;
            obstaculo = Random.Range(0, (int)n_obstaculos);
            aux_obstaculo = Obstaculos_Gerados[obstaculo].GetComponent<Obstacles_Script>();
            time_gerador = set_time();
            Gerar_Vida();
            Instantiate(Obstaculos_Gerados[obstaculo], aux_obstaculo.P_Begin(), transform.rotation);
        }
    }
    void Gerar_Vida()
    {
        if (Player.life < 90 && life_create == true)
        {
            life_create = false;
            life_pos.x = Random.Range(-10, 10);
            Instantiate(life, life_pos, transform.rotation);
        }
    }
    public float set_time()
    {
        time2 += Time.deltaTime;
        if (time2 >= time_Up && G_Min_max.y > 1)
        {
            if (G_Min_max.x > 0.1)
            {
                G_Min_max.x -= time_Quant;
            }

            G_Min_max.y -= time_Quant;
            time2 = 0;
        }
        return Random.Range(G_Min_max.x, G_Min_max.y);
    }
}
