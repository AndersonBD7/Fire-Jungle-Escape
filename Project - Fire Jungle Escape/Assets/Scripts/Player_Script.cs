using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float life_Max = 100;
    public float life;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        life = life_Max;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Obstaculo":
                break;
            case "life":
                break;
        }
    }
}
