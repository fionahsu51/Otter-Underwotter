using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float moveX;
    public float moveY;
    private float time;
    private float debugTime;
    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        debugTime = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        debugTime += Time.deltaTime;
        if (debugTime >= 1f) {
            debugTime = 0f;
            //Debug.Log(transform.position.y);
        }
    }

    void FixedUpdate() {
        float gotY = transform.position.y;
        transform.position = new Vector3(transform.position.x + moveX, transform.position.y + moveY, transform.position.z);
        if (transform.position.y > 0f && direction == "up") {
            Destroy(gameObject);
        }
        if (transform.position.x < -15f && direction == "left") {
            Destroy(gameObject);
        }
        if (transform.position.x > 15f && direction == "right") {
            Destroy(gameObject);
        }
    }
}
