using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public GameObject lightContinue, darkContinue;
    bool mouseHover = false;

    // Start is called before the first frame update
    void Start()
    {
        lightContinue.SetActive(true);
        darkContinue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0) && mouseHover == true)
        {
            SceneManager.LoadScene("OFFICIAL");
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mouseHover = true;
        lightContinue.SetActive(false);
        darkContinue.SetActive(true);
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mouseHover = false;
        lightContinue.SetActive(true);
        darkContinue.SetActive(false);
        //Debug.Log("Mouse is no longer on GameObject.");
    }
}
