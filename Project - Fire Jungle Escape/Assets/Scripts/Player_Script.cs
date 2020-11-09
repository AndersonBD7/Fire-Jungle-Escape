using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float life_Max = 100;
    public float life;
    public int points = 0;
    public float timer=0;
    public float Speed = 2;
    [SerializeField] float Jump_Height = 4;
    [SerializeField] float Jump_Strong = 100f;
    [SerializeField] bool Jump = true;
    [SerializeField] bool Arduino = true;
    
        Rigidbody rig;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        life = life_Max;
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Arduino == false)
        {
            Score(); move(); jump();
        }
    }
    void Score()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            points += 1;
            timer = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Obstaculo":
                points -= 5; life -= 10;

                break;
            case "life":
                life += 10;

                break;
        }
    }
    void move()
    {
        movement.x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        if (movement.x > -11 && movement.x < 11)
        {
            transform.Translate(movement);
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jump == true)
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
