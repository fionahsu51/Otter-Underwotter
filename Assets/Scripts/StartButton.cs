using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("Mal_prototype");
        Debug.Log("Button clicked");
    }
}