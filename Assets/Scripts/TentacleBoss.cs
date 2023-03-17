using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleBoss : Enemy
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (health <= 0)
        {
            die();
        }
    }

    public override void move()
    {

    }

}