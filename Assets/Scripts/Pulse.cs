using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial taken from here https://www.youtube.com/watch?v=0qlxrnD_8DQ&ab_channel=AlexanderZotov

public class Pulse : MonoBehaviour
{
    public float Scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("StartPulsing");
    }

    private IEnumerator StartPulsing()
    {
        for (float i = 0f; i <= Scale; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.02f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.02f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(0.015f);
        }

        for (float i = 0f; i <= Scale; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.02f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.02f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(0.015f);
        }
    }
}
