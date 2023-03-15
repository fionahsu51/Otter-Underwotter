using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public Image _image;
    public float _fadeSpeed = 0.05f;

    void Start()
    {
        StartCoroutine(Fadeout(_image, _fadeSpeed));
    }

    void Update()
    {
        // Update is empty for this purpose.
    }

    // You can use it for multiple images, just pass that image.
    IEnumerator Fadeout(Image image, float speed)
    {
        // Will run only until image's alpha becomes completely 0, will stop after that.
        while (image.color.a > 0)
        {

            // You can replace WaitForEndOfFrame with WaitForSeconds.
            yield return new WaitForSeconds(0.1f);
            Color colorWithNewAlpha = image.color;
            colorWithNewAlpha.a -= speed;
            image.color = colorWithNewAlpha;
        }
    }
}