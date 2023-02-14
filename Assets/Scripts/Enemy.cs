using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public float health;
    public float speed;
    public float leftBound;
    public float rightBound;
    protected Rigidbody2D rb;
    protected Vector3 dir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

    public abstract void move();

}
