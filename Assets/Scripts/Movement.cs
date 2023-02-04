using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 newPosition;
    public float speed;
    bool mouseHover = false;

    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        if (Input.GetMouseButton(0) && mouseHover == false)
        {
            OnMouseExit();
        }
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        mouseHover = true;
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        mouseHover = false;
        dash();
        //Debug.Log("Mouse is no longer on GameObject.");
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    void dash()
    {
        //Debug.Log("dash");
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
