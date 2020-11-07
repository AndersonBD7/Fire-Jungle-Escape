using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario_Script : MonoBehaviour
{
    [SerializeField] Move_Obj_Script move;
    [SerializeField] GameObject scenario;
    [SerializeField] Vector3 Pos_Begin = new Vector3(0, 200, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move.End(transform.position.z))
        {
            Instantiate(scenario, Pos_Begin, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.back * move.Speed * Time.deltaTime);
        }
    }
}
