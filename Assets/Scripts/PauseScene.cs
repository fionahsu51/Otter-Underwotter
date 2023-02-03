using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject quitQ;
    public GameObject pauseBackground;
    bool paused = false;

    void Start()
    {
        pauseBackground.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        quitQ.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Locked;
            pauseBackground.SetActive(true);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            quitQ.SetActive(true);
            paused = true;
            Debug.Log("Escape key was pressed");
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            pauseBackground.SetActive(false);
            yesButton.SetActive(false);
            noButton.SetActive(false);
            quitQ.SetActive(false);
            paused = false;
            Debug.Log("Escape key was pressed!");
        }

        else if (Input.GetKeyDown(KeyCode.Y) && paused == true)
        {
            Debug.Log("Y key was pressed!");
            Application.Quit();
        }

        else if (Input.GetKeyDown(KeyCode.N) && paused == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            pauseBackground.SetActive(false);
            yesButton.SetActive(false);
            noButton.SetActive(false);
            quitQ.SetActive(false);
            paused = false;
            Debug.Log("N key was pressed!");
        }
    }
}
