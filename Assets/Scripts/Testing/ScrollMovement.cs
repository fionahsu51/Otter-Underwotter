using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    Vector3 newPosition;
    public float speed;
    bool mouseHover = false;
    private float lerpVal = 0f;
    private float accelerationSpeed = 0.11f;
    public float turnRate;
    private bool moving = false;
    public Animator animator;
    public SpriteRenderer sprite;
    private float depth;
    private float timeInterval;
    
    //public GameObject background;
    //public Material Sunlight;
    //public Material TransitionSunlightMidnight;
    //private Renderer bgrenderer;

    public SpriteRenderer bg1;
    public SpriteRenderer bg2;
    public Sprite sun;
    public Sprite trans;
    public Sprite midnight;

    void Start()
    {
        depth = 0f;
        newPosition = transform.position;
        turnRate = 550f;
        timeInterval = 0f;
        //bgrenderer = background.GetComponent<Renderer>();
    }

    void Update() {
        timeInterval += Time.deltaTime;
        if (timeInterval > 1.4f) {
            timeInterval = 0f;
            //Debug.Log("depth: " + depth.ToString());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
        animator.SetBool("moving", moving);
        faceMouse();
        if (Input.GetMouseButton(0) && mouseHover == false)
        {
            if(!moving){
                moving = true;
            }
            OnMouseExit();
        }
        else
        {
            moving = false;
            lerpVal = 0f;
        }

    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mouseHover = true;
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mouseHover = false;
        dash();
        //Debug.Log("Mouse is no longer on GameObject.");
    }

    //old faceMouse.  instantly snaps to mouse position
    /*void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        if (lerpVal <= 1f) lerpVal += accelerationSpeed;
    }*/

    //new faceMouse.  Gradually turns towards mouse position at a rate of turnRate
    //adapted from:  https://answers.unity.com/questions/826613/how-would-i-slow-down-spinning-toward-the-mouse.html
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        float angle = Mathf.Atan2 (mousePosition.y - transform.position.y, mousePosition.x-transform.position.x) * Mathf.Rad2Deg;
        Quaternion qTo = Quaternion.Euler (new Vector3 (0, 0, angle - 90f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, turnRate * Time.deltaTime);

        if (lerpVal <= 1f) lerpVal += accelerationSpeed;

        if((angle > 90f && angle < 180f) || (angle < -90f && angle > -180f)){
            sprite.flipX = true;
            
        }else{
            sprite.flipX = false;
        }

    }

    void dash()
    {   
        //Debug.Log(((transform.up * Time.deltaTime * speed) * lerpVal).x);
        Vector3 gotTransform = (transform.up * Time.deltaTime * speed) * lerpVal;
        float horizontal = gotTransform.x;
        float vertical = gotTransform.y;
        //transform.position += (transform.up * Time.deltaTime * speed) * lerpVal;
        depth += vertical;
        transform.position += new Vector3(horizontal, 0f, 0f);
        //bgrenderer.material.mainTextureOffset += new Vector2(0f, vertical/40);
        bg1.transform.position += new Vector3(0f, -vertical, 0f);
        if (depth < -14f) {
            //bgrenderer.material = TransitionSunlightMidnight;
            bg1.sprite = trans;
        }
    }
}
