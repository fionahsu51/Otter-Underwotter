using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePopUp : MonoBehaviour
{

    GameObject weaponDisplay;
    GameObject healthBubble;
    GameObject depthDisplay;
    public Button option1;
    public Button option2;
    public TMP_Text option1title;
    public TMP_Text option2title;

    int option1index;
    int option2index;

    //Data structure to store upgrades
    string [,] upgrades = new string[2,2]
    {
        //0
        {"Double Damage", "Your pistol deals twice as much damage."}, 
        
        //1
        {"Shell Shock", "Your shotgun can stun enemies, holding them in place for a moment."}
    
    };

    // Start is called before the first frame update
    void Start()
    {
        //Hide gameplay UI
        weaponDisplay = GameObject.Find("Weapon Switch Display");
        healthBubble = GameObject.Find("Bubble Health");
        depthDisplay = GameObject.Find("Depth Indicator");
        
        weaponDisplay.SetActive(false);
        healthBubble.SetActive(false);
        depthDisplay.SetActive(false);

        //Get buttons, and close if they are clicked

        option1.onClick.AddListener(() => TaskOnClick(1));
        option2.onClick.AddListener(() => TaskOnClick(2));

        //Generate Upgrades
        option1index = 0;
        option2index = 1;

        //Put upgrade text on UI
        option1title.text = upgrades[option1index, 0];
        option2title.text = upgrades[option2index, 0];

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick(int button){
        if(button == 1){
            Debug.Log("option 1 clicked!");
            Close();
        }else{
            Debug.Log("option 2 clicked!");
            Close();
        }
    }

    public void Close(){
        
        weaponDisplay.SetActive(true);
        healthBubble.SetActive(true);
        depthDisplay.SetActive(true);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
