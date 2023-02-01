using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Locked;
            paused = true;
            Debug.Log("Escape key was pressed");
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            paused = false;
            Debug.Log("Escape key was pressed!");
        }
    }
}
