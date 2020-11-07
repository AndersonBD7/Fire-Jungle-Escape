using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Net.Sockets;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class Arduino_Script : MonoBehaviour
{
    [SerializeField] float Speed = 2;
    public string v = "0", d = "0";
    public float valor = 9;
    
    SerialPort porta = new SerialPort("COM3", 9600);


    // Start is called before the first frame update
    void Start()
    {
        porta.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (porta.IsOpen)
        {
            try
            {
                v = porta.ReadLine();
                setvalor();
            }
            catch (System.Exception) { }
        }
        setPos();


    }
    void setvalor()
    {

        switch (v[0])
        {
            case 'D':
                d = "";
                for (int i = 1; i <= v.Length; i++)
                {
                    d += v[i];
                    //if (i == v.Length)
                    //{
                    //    d += "\0";
                    //}
                }
                break;
        }

    }
    void setPos()
    {
        valor = float.Parse(d) ;
        valor /= 100;

        Debug.Log("Valor: " + valor);
        Debug.Log(d);

        if (transform.position.x != valor  )
        {
            if (transform.position.x > valor && transform.position.x > -11)
            {
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
            }
            if (transform.position.x < valor && transform.position.x < 11)
            {
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
            }
        }
    }
}