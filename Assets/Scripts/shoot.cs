using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float pressedSpace;
    
    // Start is called before the first frame update
    void Start()
    {
        pressedSpace = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool input = Input.GetKeyDown("space");
        //bool input2 = Keyboard.current.zButton.wasPressedThisFrame;
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }

        if (input) 
        {
            pressedSpace = 2f;
        }
        if (pressedSpace > 0) pressedSpace -= 0.1f;
    }


}
