using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private bool input;
    private float openRange = 2f;
    private bool opened = false;

    void Update() 
    {
        input = Input.GetKeyDown("c");
        GameObject otter = GameObject.Find("Otter");
        float dist = Vector3. Distance(otter.transform.position, transform.position);
        if(dist <= openRange && Input.GetKeyDown(KeyCode.C) && opened == false)
        {
            Debug.Log("opened chest");
            opened = true;
            
        }
    }

}
