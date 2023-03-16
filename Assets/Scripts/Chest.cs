using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject popUpPrefab;
    WeaponSwitching weapon;

    void Start() {
        weapon = GameObject.Find("Weapons").GetComponent<WeaponSwitching>();
    }

    void Update() 
    {
        //GameObject otter = GameObject.Find("Otter");
        //float dist = Vector3. Distance(otter.transform.position, transform.position);
        /*if(dist <= openRange && Input.GetKeyDown(KeyCode.C) && opened == false)
        {
            Debug.Log("opened chest");
            opened = true;
            Time.timeScale = 0;
            Vector3 pos = new Vector3(0, 0, 0);
            Instantiate(popUpPrefab, pos, Quaternion.identity);
            
        }*/
    }

    public void Open(){
        StartCoroutine("Deliverance");
    }

    IEnumerator Deliverance(){
        Debug.Log("March, deliverance");
        weapon.PopUp();
        Debug.Log("waiting for ready");
        yield return new WaitUntil(()=>weapon.ready == true);
        Debug.Log("making popup now");
        Time.timeScale = 0;
        Vector3 pos = new Vector3(0, 0, 0);
        Instantiate(popUpPrefab, pos, Quaternion.identity);
        Destroy(gameObject);
    }

}
