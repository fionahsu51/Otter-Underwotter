using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsFade : MonoBehaviour
{

    public Image XButton;
    public Image ZButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutImage(true, XButton));
        StartCoroutine(FadeOutImage(true, ZButton));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeOutImage(bool fadeAway, Image img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 15f; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 10; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
