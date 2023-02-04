using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    public float type;
    public float speed;
    public float leftBound;
    public float rightBound;
    private Rigidbody2D rb;
    private Vector3 dir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemy behavior varies depending on type.
        switch(type){
            case 0:
                speed = 3;

                // Code adapted from here. Thank you Zarenityx!
                // https://answers.unity.com/questions/1558555/moving-an-object-left-and-right.html
                transform.Translate(dir*speed*Time.deltaTime);
 
                if(transform.position.x <= leftBound){
                    dir = Vector3.right;
                }else if(transform.position.x >= rightBound){
                    dir = Vector3.left;
                }
                break;
            default:
                break;
        }


        if(health == 0){
            die();
        }
    }

    public void takeDamage(float dmg){

        health -= dmg;
    }

    public void die(){
        Destroy(gameObject);
    }

}
