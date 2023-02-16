using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : Enemy
{
    float startup;
    float turnRate;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        startup = 0;
        turnRate = 150f;
        renderer = GetComponent<SpriteRenderer>();
        this.speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (startup <= 1f) {
            startup += Time.deltaTime;
        }

        move();

        if(health == 0){
            die();
        }
    }

    public override void move(){
        // Code adapted from here. Thank you Zarenityx!
        // https://answers.unity.com/questions/1558555/moving-an-object-left-and-right.html
        /*transform.Translate(dir*speed*Time.deltaTime);
 
        if(transform.position.x <= leftBound){
            dir = Vector3.right;
        }else if(transform.position.x >= rightBound){
            dir = Vector3.left;
        }*/

        GameObject otter = GameObject.Find("Otter");
        Vector3 relativePos = otter.transform.position - transform.position;
        if (startup > 1f) {
            //transform.Translate(relativePos*speed*Time.deltaTime/20);
        }
        
        //rotate towards otter
        float angle = Mathf.Atan2 (otter.transform.position.y - transform.position.y, otter.transform.position.x-transform.position.x) * Mathf.Rad2Deg;
        Quaternion qTo = Quaternion.Euler (new Vector3 (0, 0, angle + 180f));
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, qTo, turnRate*Time.deltaTime);
        transform.rotation = rotation;
        float gotZ = transform.rotation.eulerAngles.z;
        if (gotZ > 90f && gotZ < 270f) { 
            renderer.flipY = true;
        } else renderer.flipY = false;

        transform.Translate(Vector3.left*speed*Time.deltaTime);

    }
}
