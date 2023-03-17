using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfEel : Enemy
{

    private int dashing = 1;
    private float turnRate = 150f;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Dash");
    }

    // Update is called once per frame
    void Update()
    {
        if(status != 1){
            move();
        }
        //Debug.Log(dashing);
        if(dashing > 0){
            speed = 12;  //default was 20
        }else{
            speed = 0;
        }

        if(health <= 0){
            die();
        }
    }

    public override void move(){
        GameObject otter = GameObject.Find("Otter");
        //Rotate eel towards player.
        //totally stole this code from casey. thank you casey! -malachi
        if(dashing < 0){
            float angle = Mathf.Atan2 (otter.transform.position.y - transform.position.y, otter.transform.position.x-transform.position.x) * Mathf.Rad2Deg;
            Quaternion qTo = Quaternion.Euler (new Vector3 (0, 0, angle + 180f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, 
                                    Time.deltaTime * turnRate);

            if((angle > 90f && angle < 180f) || (angle < -90f && angle > -180f)){
                sprite.flipY = false;    
            }else{
                sprite.flipY = true;
            }
        }
        transform.Translate(Vector3.left*speed*Time.deltaTime);  
    }

    IEnumerator Dash() {
        for(;;){
            dashing *= -1;
            //Debug.Log("coroutine called");
            //Debug.Log(dashing);
            yield return new WaitForSeconds(1.5f);
        } 
    }
}
