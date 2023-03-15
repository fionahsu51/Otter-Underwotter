using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public GameObject lightBack, darkBack;
    bool mouseHover = false;

    // Start is called before the first frame update
    void Start()
    {
        lightBack.SetActive(true);
        darkBack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && mouseHover == true)
        {
            SceneManager.LoadScene("Title_Screen");
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mouseHover = true;
        lightBack.SetActive(false);
        darkBack.SetActive(true);
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mouseHover = false;
        lightBack.SetActive(true);
        darkBack.SetActive(false);
        //Debug.Log("Mouse is no longer on GameObject.");
    }
}
