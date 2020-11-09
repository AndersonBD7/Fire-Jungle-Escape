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
    [Header("Valores Arduino")]
    [SerializeField] string v = "0";
    [SerializeField] string d = "0";
    [SerializeField] string letra = "0";

    [SerializeField] float valor_V = 0;
    [SerializeField] float valor_H = 0;

    SerialPort porta = new SerialPort("COM3", 9600);

    [Header("Valores Movimento")]
    [SerializeField] float Speed = 2;

    [Header("Valores Pulo")]
    [SerializeField] float Jump_Height = 10;
    [SerializeField] float Jump_Strong=100f;
    [SerializeField] bool Jump = true;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
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
            }
            catch
            {}
            setvalor();
        }
    }
    void setvalor()
    {
       
        d = "";
        for (int i = 1; i <= v.Length; i++)
        {
            if (i != v.Length)
            {
                d += v[i];
            }
        }
        switch (v[0])
        {
            case 'H':
                valor_H = float.Parse(d);
                setPos();
                break;
            case 'V':
                valor_V = float.Parse(d);
                jump();
                break;
        }
        Debug.Log("Setvalor");
    }
    void opcoes()
    {
        switch (v[0])
        {
            case 'H':
                setPos();
                Debug.Log("5");

                break;
            case 'V':
                jump();
                Debug.Log("4");

                break;
        }

        letra = "";
    }
    void setPos()
    {
        if (transform.position.x != valor_H)
        {
            if (transform.position.x > valor_H && transform.position.x > -11)
            {
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
            }
            if (transform.position.x < valor_H && transform.position.x < 11)
            {
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
            }
        }
    }
    void jump()
    {
        if (valor_V >= Jump_Height&&Jump==true)
        {
            rig.AddRelativeForce(new Vector3(0, Jump_Strong, 0));
            Jump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Jump == false)
            {
                Jump = true;
            }
        }
    }
}