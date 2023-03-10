using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingleScroller : MonoBehaviour
{

    public GameObject otter;
    public SpriteRenderer bg1;
    public SpriteRenderer bg2;
    //public Sprite startSprite;
    //public Sprite sunSprite;
    //public Sprite tranSunTwiSprite;
    //public Sprite twiSprite;
    //public Sprite tranTwiMidSprite;
    //public Sprite midAbSprite;
    //public Sprite tranMidAbSprite;
    //public Sprite abSprite;
    //public Sprite endSprite;

    //Non is short for Nonrepeating.
    //Re is short for repeating.  So sunNon2 is short for sunlight zon nonrepeating 1.
    public Sprite sunNon1;
    public Sprite sunNon2;
    public Sprite sunRe;
    public Sprite twiNon1T;  //T signifies that it's a transition sprite.
    public Sprite twiNon2;
    public Sprite twiRe1;
    public Sprite twiRe2;
    public Sprite twiNon3T;
    //note for Casey: REMEMBER TO UPDATE ARRAY LENGTH WITH NEW ART!!
    private Sprite[] backgrounds;
    private float depth;



    private float time;
    private int section;
    private float sectionSize;

    private float offset;
    private float start;

    //private int sunlightLimit;
    //private int twilightLimit;
    //private int midnightLimit;
    private int end;

    public int sunlightRepeats;
    public int twilightRepeats;
    public int abyssRepeats;

    public GameObject bottom;


    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        section = 0;
        start = bg1.transform.position.y/2f;

        // teleport bg2 to directly below bg1
        bg2.transform.position = new Vector3(bg1.transform.position.x, bg1.transform.position.y + bg1.bounds.size.y/2, bg2.transform.position.z);

        // populate array  UPDATE WITH NEW ART!!
        int sections = 5;  //5 for each non-repeating background
        for (int i = 0; i < sunlightRepeats + (twilightRepeats*2) + abyssRepeats; i++) {//MAKE SURE TO UPDATE abyssRepeats WITH HOW MANY REPEATS IT DOES!!!!
            sections ++;
        }
        sections++;  //because the repeating twilight background must end on repeating1
        // sections should now have correct value
        this.backgrounds = new Sprite[sections];
        backgrounds[0] = sunNon1;
        backgrounds[1] = sunNon2;
        //backgrounds
        for (int i = 2; i < sunlightRepeats + 2; i++) {
            backgrounds[i] = sunRe;  //last one is 3
        }
        int at = 1 + sunlightRepeats;
        backgrounds[++at] = twiNon1T; //4
        backgrounds[++at] = twiNon2;  //5
        int limit = at + (twilightRepeats * 2);  
        while (at < limit) {  
            backgrounds[++at] = twiRe1;
            backgrounds[++at] = twiRe2;
        }
        backgrounds[++at] = twiRe1;
        backgrounds[++at] = twiNon3T;
        // array should be populated!

        //teleport the bottom collider to the end scene
        end = backgrounds.Length - 1;
        float bottomPos = ((-end-1) * bg1.bounds.size.y);
        bottomPos += (6 * bg1.bounds.size.y) / 10;
        bottom.transform.position = new Vector3(bottom.transform.position.x, bottomPos, bottom.transform.position.z);

        string printval = "\n";
        for (int i=0; i<backgrounds.Length; i++) {
            printval += i.ToString() + " |";
            if (backgrounds[i] != null) {
                printval += backgrounds[i].name + "\n";
            } else {
                printval += "NULL\n";
            }
        }
        //Debug.Log(printval);
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1f) {
            //Debug.Log(otter.transform.position.y.ToString() + " vs " + bg1.bounds.size.y.ToString());
            //Debug.Log(section.ToString() + " vs " + backgrounds.Length.ToString() + " |ignore: " + (new System.Random()).Next().ToString());

        }
        // section holds which section the otter is at.
        section = (int)(Math.Abs(otter.transform.position.y)/bg1.bounds.size.y); 

        float halfLength = bg1.bounds.size.y/2;

        //first, find out whether otter is occupying bg1 or bg2
        SpriteRenderer occupying = null;
        SpriteRenderer other = null;
        if (otter.transform.position.y < bg1.transform.position.y + halfLength && otter.transform.position.y > bg1.transform.position.y - halfLength) {
            occupying = bg1;
            other = bg2;
        } else {
            occupying = bg2;
            other = bg1;
        }

        
        //first, detect if otter is in upper half or lower half
        section = Math.Abs( (int)( (otter.transform.position.y - halfLength) / (bg1.bounds.size.y) ) );
        float currentTop = (- section * bg1.bounds.size.y) + halfLength;
        occupying.transform.position = new Vector3(0f, -section * bg1.bounds.size.y, 0f);
        string half = "";
        if (otter.transform.position.y >= currentTop - halfLength) {
            half = "upper";
        } else {
            half = "lower";
        }
        if (half == "upper") {
            other.transform.position = new Vector3(0f, occupying.transform.position.y + occupying.bounds.size.y, 0f);
        } else if (half == "lower") {
            other.transform.position = new Vector3(0f, occupying.transform.position.y - occupying.bounds.size.y, 0f);
        }
        
        //next make sure bg1 and bg2 have the right background depending on what depth we're at
        //first, take care of occupied background
        /*if (section == 0) {
            occupying.sprite = sunSprite;
        } else if (section == 1) {
            occupying.sprite = twiSprite;
        } else if (section == 2) {
            occupying.sprite = midAbSprite;
        }*/
        occupying.sprite = backgrounds[section];

        // 0 is start
        // 1 is twilight
        // 2 is midnight/abyss

        /*
        if (half == "upper") {
            if (section == 1) other.sprite = sunSprite;
            else if (section == 2) other.sprite = twiSprite;
            else if (section == 3) other.sprite = midAbSprite;
        }
        else if (half == "lower") {
            if (section == 0) other.sprite = twiSprite;
            else if (section == 1) other.sprite = midAbSprite;
        }*/
        if (half == "upper") {
            if (section >= 1) {
                other.sprite = backgrounds[section - 1];
            } 
        }
        else if (half == "lower") {
            if (section <= backgrounds.Length - 2) {
                other.sprite = backgrounds[section + 1];
            }
        }


        if (time > 1f) time = 0f;
   }
}

