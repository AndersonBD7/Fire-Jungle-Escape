using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Script : MonoBehaviour
{
    [SerializeField] Move_Obj_Script move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
