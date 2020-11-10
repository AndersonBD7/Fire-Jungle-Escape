using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Script : MonoBehaviour
{
    [SerializeField] Move_Obj_Script move;
    [SerializeField] float Speed_Begin = 10;
    [SerializeField] Vector2 X_Min_max = new Vector2(-10, 10);
    [SerializeField] Vector3 Pos_Begin = new Vector3(0, 200, 0);

    // Start is called before the first frame update
    void Start()
    {
        move.Speed = Speed_Begin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (move.End(transform.position.z))
            {
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(Vector3.back * move.Speed * Time.deltaTime);
            }
        }
    }

    public Vector3 P_Begin()
    {
        Pos_Begin.x = Random.Range(X_Min_max.x, X_Min_max.y);
        return Pos_Begin;
    }
}
