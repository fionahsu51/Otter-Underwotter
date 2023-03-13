using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    public GameObject[] sunNonCollidablesLeft;
    public GameObject[] sunNonCollidablesRight;
    public GameObject[] twiNonCollidablesLeft;
    public GameObject[] twiNonCollidablesRight;
    public GameObject greg;
    private int lastSunlight;
    private int lastTwilight;
    private int lastAbyss;
    public float parallaxRate;
    private List<int> visitedSections;
    private List<GameObject> spawnedNonCollidablesLeft;
    private List<GameObject> spawnedNonCollidablesRight;
    private float sectionHeight;
    private float sectionWidth;
    private float sectionScale;
    //private float minSeparation;
    //private float maxSeparation;

    public GameObject test;


    // Start is called before the first frame update
    void Start()
    {
        //lastSunlight = greg.GetComponent<Scroller>().lastSunlight;
        //lastTwilight = greg.GetComponent<Scroller>().lastTwilight;

        parallaxRate = 0.6f;
        //minSeparation = 1f; //these values aren't actually used.  just a bit of safety against an infinite do-while loop
        //maxSeparation = 3f;


        //Instantiate(testPrefab, new Vector3(0f, -12f, 0f), Quaternion.identity);

        //sunlight zone
        //each for loop iteration is 1 section

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lastSunlight == 0) { //need to do this in update to give Scroller time to update its info before I retrieve it
            lastAbyss = greg.GetComponent<Scroller>().lastAbyss;
            sectionHeight = greg.GetComponent<Scroller>().sectionSize;
            sectionWidth = greg.GetComponent<Scroller>().sectionWidth;
            sectionScale = greg.GetComponent<Scroller>().sectionScale;
            lastSunlight = greg.GetComponent<Scroller>().lastSunlight;
            lastTwilight = greg.GetComponent<Scroller>().lastTwilight;
            //minSeparation = 2f;
            //maxSeparation = 5f;
            for (int i = -1; i >= -lastSunlight; i--) {
                //float at = i * sectionHeight/2;
                float at = i * sectionHeight;
                do {
                    //at -= UnityEngine.Random.Range(minSeparation, maxSeparation);
                    at -= 0.8f;
                    //Debug.Log(UnityEngine.Random.Range(minSeparation, maxSeparation));
                    //at -= 0.2f;
                    Instantiate(sunNonCollidablesLeft[Random.Range(0, sunNonCollidablesLeft.Length)], new Vector3(-sectionWidth/3 - 2f, at, 0f), Quaternion.identity);
                } while (at > i * sectionHeight);//while (at > (((i * sectionHeight) - sectionHeight/2) / 2) - 10f);
                //at = i * sectionHeight;      
                /*do {
                    at -= UnityEngine.Random.Range(minSeparation, maxSeparation);
                    //Debug.Log(UnityEngine.Random.Range(minSeparation, maxSeparation));
                    //at -= 0.2f;
                    Instantiate(sunNonCollidablesLeft[Random.Range(0, sunNonCollidablesLeft.Length)], new Vector3(-sectionWidth/3 - 2f, at, 0f), Quaternion.identity);
                } while (at > (((i * sectionHeight) - sectionHeight/2) / 2) - 10f);
                //Debug.Log(sunNonCollidablesLeft.Length);Random.Range(0, sunNonCollidablesLeft.Length)
                */
            }
        }


        int section = greg.GetComponent<Scroller>().section;

        
    }
}
