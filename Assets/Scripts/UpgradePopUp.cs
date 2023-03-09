using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePopUp : MonoBehaviour
{

    GameObject weaponDisplay;
    GameObject healthBubble;
    GameObject depthDisplay;
    public Button option1;
    public Button option2;

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
