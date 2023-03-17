using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaAngel : Enemy
{
    float distance;
    bool startMoving;

    // Start is called before the first frame update
    void Start()
    {
        this.distance = 9f;
        this.startMoving = false;
    }

    // Update is called once per frame
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
        GameObject otter = GameObject.Find("Otter");

        float dist = Vector3.Distance(otter.transform.position, transform.position);
        if (!this.startMoving)
        {
            if (dist < this.distance)
            {
                this.startMoving = true;
            }
        }

        else if(this.startMoving)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            dir = Vector3.up;
        }
    }
}
