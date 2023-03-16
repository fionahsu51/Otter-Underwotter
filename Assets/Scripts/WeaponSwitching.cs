using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script from https://www.youtube.com/watch?v=Dn_BUIVdAPg&ab_channel=Brackeys
public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public bool popup = false;
    public bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetKeyDown(KeyCode.Z) && Time.timeScale > 0)
        {
            if(selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            
            else
            {
                selectedWeapon++;
            }
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    
    public void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void PopUp(){
        Debug.Log("activating weapons");
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(true);
        }
        ready = true;
        Debug.Log("activated weapons");
    }
}
