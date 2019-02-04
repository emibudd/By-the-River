using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    int direction_idle = 0;
    public float speed = 0.1f;
    public Animator anim;
    GameObject camera;

    float timer_right = 0f;
    float timer_left = 0f;
    float timer_up = 0f;
    float timer_down = 0f;

    void Start()
    {

        camera = GameObject.Find("Main Camera");

        anim = GetComponent<Animator>();

    }

    void Update()
    {

        //To let the player move the Blue Sigma and trigger the moving animations.

        if (Input.GetKey(KeyCode.D))
        {
            timer_right += 1;
        }

        else
        {
            timer_right = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            timer_up += 1;
        }

        else
        {
            timer_up = 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            timer_left += 1;
        }

        else
        {
            timer_left = 0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            timer_down += 1;
        }

        else
        {
            timer_down = 0f;
        }



        if (Input.GetKey(KeyCode.D) && (timer_left == 0f || timer_right <= timer_left))
        {
            Vector3 position = this.transform.position;
            position.x = position.x + Time.deltaTime * speed;
            this.transform.position = position;
            anim.Play("Blue Forward State");
            direction_idle = 2;

        }

        if (Input.GetKey(KeyCode.A) && (timer_right == 0f || timer_left <= timer_right))
        {
            Vector3 position = this.transform.position;
            position.x = position.x - Time.deltaTime * speed;
            this.transform.position = position;
            anim.Play("Blue Back State");
            direction_idle = 3;

        }

        if (Input.GetKey(KeyCode.W) && (timer_down == 0f || timer_up <= timer_down))
        {
            Vector3 position = this.transform.position;
            position.y = position.y + Time.deltaTime * speed;
            this.transform.position = position;

            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow))
            {
                anim.Play("Blue Up State");
                direction_idle = 1;
            }
        }

        if (Input.GetKey(KeyCode.S) && (timer_up == 0f || timer_down <= timer_up))
        {
            Vector3 position = this.transform.position;
            position.y = position.y - Time.deltaTime * speed;
            this.transform.position = position;

            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow))
            {
                anim.Play("Blue Down State");
                direction_idle = 4;
            }
        }

        //To activate the idle state

        if (Input.anyKey == false)
        {
            anim.Play("Idle");
        }
    }
}