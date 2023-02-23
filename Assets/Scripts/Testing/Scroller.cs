using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scroller : MonoBehaviour
{

    public GameObject otter;
    public SpriteRenderer bg1;
    public SpriteRenderer bg2;
    public Sprite sun;
    public Sprite trans;
    public Sprite midnight;
    private float depth;

    private float time;
    private int section;
    private float sectionSize;

    private float offset;
    private float start;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        section = 0;
        //bg1.transform.position = new Vector3(bg1.transform.position.x, -bg1.bounds.size.y/2f, 0f)
        start = bg1.transform.position.y/2f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1f) {
            time = 0f;
            //Debug.Log(otter.transform.position.y.ToString() + " vs " + bg1.bounds.size.y.ToString());
            Debug.Log(bg1.transform.position.y);
        }
        section = (int)Math.Abs(otter.transform.position.y/bg1.bounds.size.y); 

        float halfLength = bg1.bounds.size.y/2;

        //first, find out whether otter is occupying bg1 or bg2
        SpriteRenderer occupying = null;
        SpriteRenderer other = null;
        //Debug.Log(otter.transform.position.y.ToString() + " < " + (bg1.transform.position.y + halfLength).ToString());
        //Debug.Log(otter.transform.position.y.ToString() + " < ")
        if (otter.transform.position.y < bg1.transform.position.y + halfLength && otter.transform.position.y > bg1.transform.position.y - halfLength) {
            occupying = bg1;
            other = bg2;
        } else {
            occupying = bg2;
            other = bg1;
        }


        //first, detect if otter is in upper half or lower half
        int currentSection = -(int)( (otter.transform.position.y - halfLength) / (occupying.bounds.size.y) );
        float currentTop = (-currentSection * occupying.bounds.size.y) + halfLength;
        string half = "";
        if (otter.transform.position.y >= currentTop - halfLength) {
            half = "upper";
        } else {
            half = "lower";
        }
        if (half == "upper") {
            other.transform.position = new Vector3(0f, occupying.transform.position.y + occupying.bounds.size.y, 0f);
        } else {
            other.transform.position = new Vector3(0f, occupying.transform.position.y - occupying.bounds.size.y, 0f);
        }

        //next, make sure otter is always occupying bg1
        /*if (otter.transform.position.y > bg1.transform.position.y + halfLength || otter.transform.position.y < bg1.transform.position.y - halfLength) {
            Vector3 relay = bg1.transform.position;
            bg1.transform.position = bg2.transform.position;
            bg2.transform.position = relay;
            Debug.Log("Switch!  " + (new System.Random()).Next().ToString());
        }*/


   }
}
