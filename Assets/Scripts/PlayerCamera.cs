using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public Transform followTransform;
    ///public Vector3 minValues, maxValue;
    public float smoothFactor;

    public GameObject trackTargetLeft;
    public GameObject trackTargetRight;
    


    // Update is called once per frame

    // Code adapted from this tutorial https://www.youtube.com/watch?v=Fqht4gyqFbo&ab_channel=Antarsoft 
    void FixedUpdate()
    {
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        
        //Vector3 targetPosition = followTransform.position;

        ////Set the camera boundaires to the edges of the background
        //Vector3 boundPosition = new Vector3(
        //    Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
        //    Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
        //    Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z));
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        //transform.position = smoothPosition;


        // [Casey]  I've modified this script so that the camera tracks the Left and Right colliders.
        // all of Fiona's original code is just commented out.  If you're reactivating it, don't
        // forget to uncomment the public minValues, maxValue declaration up top.
        Vector3 targetPosition = followTransform.position;
        float minX = trackTargetLeft.transform.position.x;
        float maxX = trackTargetRight.transform.position.x;
        float minY = trackTargetLeft.transform.position.y - trackTargetLeft.GetComponent<BoxCollider2D>().size.y / 2;
        float maxY = trackTargetLeft.transform.position.y + trackTargetLeft.GetComponent<BoxCollider2D>().size.y / 2;
        Camera cam = GetComponent<Camera>();
        float height = cam.orthographicSize;
        float aspect = cam.aspect;
        float camWidth = height * aspect;
        camWidth += camWidth / 10;

        //Set the camera boundaries to the edges of the background
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minX + camWidth, maxX - camWidth),
            Mathf.Clamp(targetPosition.y, minY, maxY),
            Mathf.Clamp(targetPosition.z, -10, -10));
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;

    }
}