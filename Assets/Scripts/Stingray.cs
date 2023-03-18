using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stingray : Enemy
{
    bool switchDirection;

    //Max x-coordinates stingray can move side-to-side within
    public float leftMax;
    public float rightMax;
    SpriteRenderer renderer;
    private AudioSource deathSFX;

    void Start()
    {
        switchDirection = false;
        renderer = GetComponent<SpriteRenderer>();
        deathSFX = GameObject.Find("Death_Anouncer").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(status != 1){
            move();
        }

        if (health <= 0)
        {
            deathSFX.Play();
            die();
        }
        //if too far from otter, despawn
        if (Vector3.Distance(GameObject.Find("Otter").transform.position, transform.position) > 20f) Destroy(gameObject);
    }

    public override void move()
    {
        if (switchDirection == false)
        {
            if(this.transform.position.x >= rightMax)
            {
                switchDirection = true;
                renderer.flipX = true;
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
                renderer.flipX = false;
            }

            else
            {
                transform.Translate(dir * speed * Time.deltaTime);
                dir = Vector3.left;
            }
         }
    }
}