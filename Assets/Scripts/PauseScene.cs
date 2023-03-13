using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScene : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public GameObject quitQ;
    //public GameObject pauseBackground;
    //public GameObject weaponDisplay;
    bool paused = false;

    void Start()
    {
        //pauseBackground.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        quitQ.SetActive(false);
        yesButton.onClick.AddListener(() => TaskOnClick(1));
        noButton.onClick.AddListener(() => TaskOnClick(2));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && paused == false)
        {
            Time.timeScale = 0;
            //Cursor.lockState = CursorLockMode.Locked;
            //pauseBackground.SetActive(true);
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
            quitQ.SetActive(true);
            //weaponDisplay.SetActive(false);
            paused = true;
            Debug.Log("Escape key was pressed");
        }

        else if (Input.GetKeyDown(KeyCode.P) && paused == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            //pauseBackground.SetActive(false);
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            quitQ.SetActive(false);
            //weaponDisplay.SetActive(true);
            paused = false;
            Debug.Log("Escape key was pressed!");
        }

        /*else if (Input.GetKeyDown(KeyCode.Y) && paused == true)
        {
            Debug.Log("Y key was pressed!");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Title_Screen");
        }

        else if (Input.GetKeyDown(KeyCode.N) && paused == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            //pauseBackground.SetActive(false);
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            quitQ.SetActive(false);
            //weaponDisplay.SetActive(true);
            paused = false;
            Debug.Log("N key was pressed!");
        }*/
    }

    void TaskOnClick(int button){
        if(button == 1){
            Debug.Log("Quit clicked!");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Title_Screen");
        }else{
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            //pauseBackground.SetActive(false);
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
            quitQ.SetActive(false);
            //weaponDisplay.SetActive(true);
            paused = false;
            Debug.Log("Resume clicked!");
        }
    }
}
