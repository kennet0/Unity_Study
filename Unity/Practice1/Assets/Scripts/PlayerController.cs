using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        
    }
    
    void Update()
    {
        // Local -> World
        // TransformDirection

        // World -> Local
        //InverseTransformDirection 

        if (Input.GetKey(KeyCode.W))
            transform.Translate(transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed));

        if (Input.GetKey(KeyCode.S))
            transform.Translate(transform.TransformDirection(Vector3.back * Time.deltaTime * _speed));

        if (Input.GetKey(KeyCode.A))
            transform.Translate(transform.TransformDirection(Vector3.left * Time.deltaTime * _speed));

        if (Input.GetKey(KeyCode.D))
            transform.Translate(transform.TransformDirection(Vector3.right * Time.deltaTime * _speed));

    }
}
