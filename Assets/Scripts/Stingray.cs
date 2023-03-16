using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stingray : Enemy
{
    bool switchDirection;

    //Max x-coordinates stingray can move side-to-side within
    public float leftMax;
    public float rightMax;

    void Start()
    {
        switchDirection = false;
    }

    void Update()
    {
        if(status != 1){
            move();
        }

        if (health <= 0)
        {
            die();
        }
    }

    public override void move()
    {
        if (switchDirection == false)
        {
            if(this.transform.position.x >= rightMax)
            {
                switchDirection = true;
            }

            else
            {
                transform.Translate(dir * speed * Time.deltaTime);
                dir = Vector3.right;
            }            
        }

         if (switchDirection == true)
         {
            if (this.transform.position.x <= leftMax)
            {
                switchDirection = false;
            }

            else
            {
                transform.Translate(dir * speed * Time.deltaTime);
                dir = Vector3.left;
            }
         }
    }
}