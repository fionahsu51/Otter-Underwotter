using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBob : MonoBehaviour
{

    // Made with help from here. Thank you Diericx and hassonhamo3!
    // https://forum.unity.com/threads/how-to-make-an-object-move-up-and-down-on-a-loop.380159/

    public float speed;
    public float height;
    private Vector3 pos;
    public bool sincos;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY;
        //calculate what the new Y position will be
        if(sincos == true){
            newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        }else{
            newY = Mathf.Cos(Time.time * speed) * height + pos.y;
        }
        
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
