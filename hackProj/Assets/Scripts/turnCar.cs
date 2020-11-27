using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnCar : MonoBehaviour
{   /*
    public float delta_turn;
    public float speed_turn;

    private float turn_cord = 0f;
    private Transform _turn;
    */
    public static float const_speed = 2f;
    public float speed = const_speed;
    public float sharpness = 2.5f;
    public float acceleration = 0.5f;
    private float last_dir = 0;

    public int go = 0;
    public float go_speed = 2f;



    void Start()
    {
      //  _turn = GetComponent<Transform>();
    }

    void Update()
    {
        
        float dir_key = -Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(dir_key, 0, 0);
        if (transform.position.x < 4 && transform.position.x > -4) {
            if (dir_key != 0)
            {
                last_dir = dir_key;
                transform.Translate(dir.normalized * speed * Time.deltaTime);
                speed += acceleration;
            } else if (speed - const_speed > acceleration && dir_key == 0)
            {
                transform.Translate(last_dir * speed * Time.deltaTime, 0, 0);
                speed -= acceleration * sharpness;
            }
        }

        if (transform.position.x >= 4)
        {
            speed = const_speed;
            transform.Translate(-0.5f, 0, 0);
        } else if (transform.position.x <= -4)
        {
            speed = const_speed;
            transform.Translate(0.5f, 0, 0);
        }


        if (Input.GetKey(KeyCode.RightArrow) && transform.position.z < 15)
        {
            transform.Translate(0, 0, go_speed * Time.deltaTime);
            //go++;
        } else if (transform.position.z > 2.25)
        {
            transform.Translate(0, 0, -go_speed * Time.deltaTime);
            //go--;
        }
        //transform.Translate(dir.normalized * speed * Time.deltaTime);

        /*
        float i = 0;
        if (Input.GetKey(KeyCode.W))
        {
            if (turn_cord < delta_turn && i < delta_turn) {
                _turn.transform.Translate(speed_turn * Time.deltaTime, 0, 0);
                turn_cord += speed_turn;
                i += speed_turn;
            }
        } else if (Input.GetKey(KeyCode.S))
        {
            if ((turn_cord > -delta_turn && i < delta_turn)) {
                _turn.transform.Translate(-speed_turn * Time.deltaTime, 0, 0);
                turn_cord -= speed_turn;
                i += speed_turn;
            }
        }
        */

    }
}
