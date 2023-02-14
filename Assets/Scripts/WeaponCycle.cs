using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCycle : MonoBehaviour
{

    //public string[] weaponsArray = new string[] { "slingshot", "shield", "ball" };
    /// public GameObject[] weaponsDisplayArray = GameObject[] {"slingshotDisplay", "shieldDisplay", "ballDisplay"};
    //var weaponsList = weaponsArray.ToList();
    //weaponsList.Add("ball");
    //weaponsArrary = weaponsList.ToArray();

    //string[] weaponsArray = new string[] { "slingshot", "shield" };
    //string ball = "ball";
    //weaponsArray = weaponsArray.Append(ball).ToArray();

    public GameObject[] weaponsDisplay; 
    public GameObject slingshotDisplay;
    public GameObject shieldDisplay;
    public GameObject ballDisplay;

    bool ballObtained = false;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
       /// weaponsDisplay = new GameObject[3];

        slingshotDisplay.SetActive(true);
        shieldDisplay.SetActive(false);
        ballDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Z")){
            if (i == 0)
            {

            }
            if (i == 1)
            {
                slingshotDisplay.SetActive(false);
                shieldDisplay.SetActive(true);
                i++;
            }
            else if(ballObtained == false)
            {
                i = 0;
            }

            else if(i == 2 && ballObtained == true)
            {
                shieldDisplay.SetActive(false);
                ballDisplay.SetActive(true);   
            }
        }
    }
}
