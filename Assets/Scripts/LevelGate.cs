using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate : MonoBehaviour
{
    public bool activated = false;
    public string test = "TESTETSETESTST";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (activated && collision.gameObject.name == "Otter")
        {
            string now =  SceneManager.GetActiveScene().name;
            string next = "";
            if (now == "Mal_prototype") next = "Level2_Twilight";
            else if (now == "Level2_Twilight") next = "Level3_Midnight";
            else if (now == "Level3_Midnight") next = "Level4_Abyss";
            else if (now == "Level4_Abyss") next = "Level5_Trench";

            //print("LEVELGATE COLLISION DETECTED");
            SceneManager.LoadScene(next, LoadSceneMode.Single);
        }
    }

}
