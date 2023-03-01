using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("New_Fiona");
        }

        else if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Title_Screen");
        }
    }
}
