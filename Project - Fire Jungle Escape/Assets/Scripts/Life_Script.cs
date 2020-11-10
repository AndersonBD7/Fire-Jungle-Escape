using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Script : MonoBehaviour
{
    [SerializeField] Move_Obj_Script move;
    [SerializeField] Gerador_Script gerador;
    // Start is called before the first frame update
    void Start()
    {
        gerador = GameObject.Find("Gerador de Obstaculos").GetComponent<Gerador_Script>();
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
    private void OnDestroy()
    {
        gerador.life_create = true;
    }
}
