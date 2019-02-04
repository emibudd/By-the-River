using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationShooting : MonoBehaviour
{

     public float speed = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 position = this.transform.position;
        position.x = position.x + Time.deltaTime * speed;
        this.transform.position = position;


    }
}
