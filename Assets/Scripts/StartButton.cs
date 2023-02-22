using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public AudioSource bubblePop;
    public void OnButtonPress()
    {
        SceneManager.LoadScene("New_Fiona");
        Debug.Log("Button clicked");
        bubblePop.Play();
    }
}