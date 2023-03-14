using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public AudioSource bubblePop;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode); 
    }

    public void OnButtonPress()
    {
        bubblePop.Play();
        StartCoroutine("LoadLevel");
        ///SceneManager.LoadScene("Instructions");
        Debug.Log("Button clicked");
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Instructions");
    }
}