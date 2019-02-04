using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueShoot : MonoBehaviour
{

    float timer = 0f;

    public Transform bullet;

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Q) && (timer <= 0))
        {
            Instantiate(bullet, new Vector3(this.transform.position.x+0.24f, this.transform.position.y, -5f), Quaternion.identity);
            timer = 1f;

        }

    }
}
