using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if(health == 0){
            die();
        }
    }

    public override void move(){
        // Code adapted from here. Thank you Zarenityx!
        // https://answers.unity.com/questions/1558555/moving-an-object-left-and-right.html
        transform.Translate(dir*speed*Time.deltaTime);
 
        if(transform.position.x <= leftBound){
            dir = Vector3.right;
        }else if(transform.position.x >= rightBound){
            dir = Vector3.left;
        }
    }
}
