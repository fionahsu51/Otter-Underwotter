using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaAngel : Enemy
{
    float distance;
    bool startMoving;
    private AudioSource deathSFX;

    // Start is called before the first frame update
    void Start()
    {
        this.distance = 9f;
        this.startMoving = false;
        deathSFX = GameObject.Find("Death_Anouncer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
