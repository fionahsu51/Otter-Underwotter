using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{



    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Otter")
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
        }
    }
}
