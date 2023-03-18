using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : Enemy
{
    float startup;
    float turnRate;
    float originalTurnRate;
    SpriteRenderer renderer;
    float inflateDistance;
    bool inflated;
    public Sprite inflatedSprite;
    private float originalSpeed;
    private BoxCollider2D collider;
    public float scaleIncrease;
    public AudioSource inflateSFX;
    private AudioSource deathSFX;
    public Animator animator;

    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        this.startup = 0;
        this.turnRate = 150f;
        this.originalTurnRate = this.turnRate;
        this.renderer = GetComponent<SpriteRenderer>();
        this.speed = 2f;
        this.originalSpeed = this.speed;
        this.inflateDistance = 2f;
        this.inflated = false;
        this.collider = GetComponent<BoxCollider2D>();
        this.scaleIncrease = 2.5f;
        animator = GetComponent<Animator>();
        deathSFX = GameObject.Find("Death_Anouncer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("inflated", inflated);
        
        if (startup <= 1f) {
            startup += Time.deltaTime;
        }

        if(status != 1){
            move();
        }
        
        if (health <= 0) {
            deathSFX.Play();
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

        //move towards otter at a rate of speed variable
        transform.Translate(Vector3.left*speed*Time.deltaTime);
        
        // if close enough, inflate.
        // controlled by this.inflated bool variable
        if (!this.inflated) {
            float dist = Vector3.Distance(otter.transform.position, transform.position);
            if (dist < this.inflateDistance) {
                inflateSFX.Play();
                //transform.localScale = new Vector3(transform.localScale.x*this.scaleIncrease, transform.localScale.y*this.scaleIncrease, 0f);
                this.renderer.sprite = inflatedSprite;
                this.speed = 0f;
                this.turnRate = 0f;
                this.inflated = true;
                // increase BoxCollider2D size to scale with new sprite
                collider.size = new Vector2(collider.size.x * this.scaleIncrease, collider.size.y * this.scaleIncrease);
            }
        } else {
            //now lerp movement speed and turn rate to a rate that's a bit below uninflated speeds
            float moveLerpRate = 0.3f;
            float inflatedSpeed = originalSpeed * 0.4f;
            float turnLerpRate = 20f;
            float inflatedTurnRate = originalTurnRate * 0.7f;
            if (speed < inflatedSpeed) {
                speed += moveLerpRate * Time.deltaTime;
            }
            if (this.turnRate < inflatedTurnRate) {
                this.turnRate += turnLerpRate * Time.deltaTime;
            }
        }
        
    }

}
