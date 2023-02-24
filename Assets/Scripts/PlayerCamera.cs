using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform followTransform;
    public Vector3 minValues, maxValue;
    public float smoothFactor;

    // Update is called once per frame

    // Code adapted from this tutorial https://www.youtube.com/watch?v=Fqht4gyqFbo&ab_channel=Antarsoft 
    void FixedUpdate()
    {
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);

        Vector3 targetPosition = followTransform.position;

        //Set the camera boundaires to the edges of the background
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z));
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}