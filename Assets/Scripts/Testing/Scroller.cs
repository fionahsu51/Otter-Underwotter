using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scroller : MonoBehaviour
{

    public GameObject otter;
    public SpriteRenderer bg1;
    public SpriteRenderer bg2;
    public Sprite sunSprite;
    public Sprite transMidSprite;
    public Sprite midnightSprite;
    private float depth;

    private float time;
    private int section;
    private float sectionSize;

    private float offset;
    private float start;

    public int sunlightBound;
    public int midnightBound;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        section = 0;
        //bg1.transform.position = new Vector3(bg1.transform.position.x, -bg1.bounds.size.y/2f, 0f)
        start = bg1.transform.position.y/2f;

        sunlightBound = 4;
        midnightBound = 10;

        //bg1.sprite = midnightSprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1f) {
            time = 0f;
            //Debug.Log(otter.transform.position.y.ToString() + " vs " + bg1.bounds.size.y.ToString());
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
        section = Math.Abs( (int)( (otter.transform.position.y - halfLength) / (occupying.bounds.size.y) ) );
        float currentTop = (- section * occupying.bounds.size.y) + halfLength;
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

        //next make sure bg1 and bg2 have the right background depending on what depth we're at
        //first, take care of occupied background
        if (section < sunlightBound) {
            occupying.sprite = sunSprite;
        } else if (section == sunlightBound) {
            occupying.sprite = transMidSprite;
        } else if (section > sunlightBound) {  //&& section < midnightBound
            occupying.sprite = midnightSprite;
        }

        
        //now take care of other background
        if (section == sunlightBound - 1 && half == "lower") {
            other.sprite = transMidSprite;
        } else if (section == sunlightBound && half == "upper") {
            other.sprite = sunSprite;
        } else if (section == sunlightBound && half == "lower") {
            other.sprite = midnightSprite;
        } else if (section == sunlightBound + 1 && half == "upper") {
            other.sprite = transMidSprite;
        } else if (section == sunlightBound + 1 && half == "lower") {
            other.sprite = midnightSprite;
        }

   }
}
