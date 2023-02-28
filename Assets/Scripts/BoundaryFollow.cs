using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes the boundaries track the otter's y position.  I.E. it goes up and down with the otter.
public class BoundaryFollow : MonoBehaviour
{
    public GameObject otter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, otter.transform.position.y, transform.position.z);   
        //Debug.Log(transform.position);
    }
}
