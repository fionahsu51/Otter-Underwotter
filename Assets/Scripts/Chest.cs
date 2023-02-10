using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private bool input;

    void Update() 
    {
        input = Input.GetKeyDown("space");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        /*if (collision.gameObject.name == "Otter")
        {
            Debug.Log("Collision detected");
            GameObject levelgate = GameObject.Find("LevelGate");
            print(levelgate);
            if (levelgate != null) {
                LevelGate script;
                script = levelgate.GetComponent<LevelGate>();
                script.activated = true;
                Destroy(gameObject);
            }
            //print(levelgate.activated);
        }*/
    }

    void OnTriggerStay2D(Collider2D collision) 
    {

        if (collision.gameObject.name == "Otter" && collision.GetComponent<shoot>().pressedSpace > 0f)
        {
            GameObject levelgate = GameObject.Find("LevelGate");
            if (levelgate != null) {
                LevelGate script;
                script = levelgate.GetComponent<LevelGate>();
                script.activated = true;
                Destroy(gameObject);
            }
        }
    }
}
