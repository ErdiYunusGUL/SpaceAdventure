using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float maxSpeed;


    bool movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = true;
        
        if (Registrations.EasyValueGet() == 1)
        {
            speed = 0.3f;
            acceleration = 0.03f;
            maxSpeed = 1.5f;
        }

        if (Registrations.NormalValueGet() == 1)
        {
            speed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 2.0f;
        }

        if (Registrations.HardValueGet() == 1)
        {
            speed = 0.8f;
            acceleration = 0.08f;
            maxSpeed = 2.5f;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            MoveCamera();
        }
    }

    void MoveCamera ()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void GameOver()
    {
        movement = false;
    }
}
