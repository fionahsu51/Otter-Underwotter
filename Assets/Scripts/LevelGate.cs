using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            print("LEVELGATE COLLISION DETECTED");
        }
    }

}
