using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public AudioSource bubblePop;
    public AudioSource deathSound;

    void Start()
    {
        yesButton.onClick.AddListener(() => TaskOnClick(1));
        noButton.onClick.AddListener(() => TaskOnClick(2));
        deathSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("OFFICIAL");
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Title_Screen");
        }*/
    }

    void TaskOnClick(int button){
        if(button == 1){
            bubblePop.Play();
            StartCoroutine("LoadLevel");
        }
        else{
            bubblePop.Play();
            StartCoroutine("LoadTitle");
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("OFFICIAL");
    }

    IEnumerator LoadTitle()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Title_Screen");
    }
}
