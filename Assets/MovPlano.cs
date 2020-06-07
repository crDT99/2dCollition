using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlano : MonoBehaviour
{
    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posicion = gameObject.GetComponent<Transform>().position;
        if (Input.GetKey(KeyCode.W))
            posicion.z = posicion.z + 0.05f;
        if (Input.GetKey(KeyCode.S))
            posicion.z = posicion.z - 0.05f;
        if (Input.GetKey(KeyCode.D))
            posicion.x = posicion.x + 0.05f;
        if (Input.GetKey(KeyCode.A))
            posicion.x = posicion.x - 0.05f;
        gameObject.GetComponent<Transform>().position = posicion;
    }
}
