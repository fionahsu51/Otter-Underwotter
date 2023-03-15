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
    public TMP_Text option1desc;
    public TMP_Text option2desc;
    shoot pistol;
    //AlternateShoot shotgun;
    bool NoMoreUpgrades = false;

    //AlternateShoot shotgun;

    int option1index;
    int option2index;

    //Data structure to store upgrades
    string [,] upgrades = new string[6,2]
    {
        //0
        {"Crustacean Devastation", "Your pistol deals twice as much damage."}, 
        
        //1
        {"Shell Shock", "Your shotgun can stun enemies, holding them in place for a moment."},

        //2
        {"Prawn Pistol", "Oh whoops, I dropped my magnum shrimp...."},

        //3
        {"Bivalve Barrel", "Who said shotguns need to have a short range?"},

        //4
        {"Conchentrated Fire", "Your shotgun can fire much faster."},

        //5
        {"Swimmeret Shot", "Your pistol bullets move faster."}
    
    };

    // Start is called before the first frame update
    void Start()
    {
        //Hide gameplay UI
        weaponDisplay = GameObject.Find("Weapon Switch Display");
        healthBubble = GameObject.Find("Bubble Health");
        depthDisplay = GameObject.Find("Depth Indicator");
        pistol = GameObject.Find("Pistol").GetComponent<shoot>();
        //shotgun = GameObject.Find("Shotgun").GetComponent<AlternateShoot>();
        
        //weaponDisplay.SetActive(false);
        //healthBubble.SetActive(false);
        //depthDisplay.SetActive(false);

        //Get buttons, and close if they are clicked

        option1.onClick.AddListener(() => TaskOnClick(1));
        option2.onClick.AddListener(() => TaskOnClick(2));

        //Generate Upgrades
        if(pistol.takenIndices.Count <= 5){
            option1index = Random.Range(0, 6);
            while(pistol.takenIndices.Contains(option1index)){
                option1index = Random.Range(0, 6);
            }
        
            if(pistol.takenIndices.Count >= 5){
                option2index = option1index;
            }else{
                option2index = Random.Range(0, 6);
                while(option2index == option1index || pistol.takenIndices.Contains(option2index)){
                    option2index = Random.Range(0, 6);
                }
            }

            //Put upgrade text on UI
            option1title.text = upgrades[option1index, 0];
            option2title.text = upgrades[option2index, 0];
            option1desc.text = upgrades[option1index, 1];
            option2desc.text = upgrades[option2index, 1];
        }else{
            NoMoreUpgrades = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(NoMoreUpgrades == true){
            Close();
        }
    }

    void TaskOnClick(int button){
        if(button == 1){
            Debug.Log("option 1 clicked!");
            ApplyUpgrade(option1index);
            pistol.takenIndices.Add(option1index);
            Close();
        }else{
            Debug.Log("option 2 clicked!");
            ApplyUpgrade(option2index);
            pistol.takenIndices.Add(option2index);
            Close();
        }
    }

    public void Close(){
        Debug.Log(pistol.takenIndices.Count);
        //weaponDisplay.SetActive(true);
        //healthBubble.SetActive(true);
        //depthDisplay.SetActive(true);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    void ApplyUpgrade(int index){
        switch(index){
            case 0:
                pistol.damage = 20f;
                Debug.Log("Pistol damage: ");
                Debug.Log(pistol.damage);
                break;
            case 2:
                pistol.scale = 0.9f;
                pistol.speed = 10f;
                Debug.Log("case 2");
                break;
            case 4:
                shotgun.fireRate = 0.6f;
                Debug.Log("case 4");
                break;
            case 5:
                pistol.speed *= 1.5f;
                Debug.Log("case 5");
                Debug.Log(pistol.speed);
                break;
            default:
                Debug.Log("No upgrade applied");
                break;
        }
    }

}
