using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public AudioSource endTheme;
    public int selectedPanel = 0;
    public Image _image;
    public Image TYText;
    public float _fadeSpeed = 0.05f;
    private bool lastPanel = false;

    void Start()
    {
        SelectPanel();
        //StartCoroutine(Fadeout(_image, _fadeSpeed));
    }

    void Update()
    {
        int previousSelectedPanel = selectedPanel;

        if (Input.GetKeyDown(KeyCode.X) && Time.timeScale > 0)
        {
            if (selectedPanel == 9)
            {
                lastPanel = true;
                //StartCoroutine(Fadeout(_image, _fadeSpeed));
            }

            else
            {
                selectedPanel++;
            }
        }

        if (previousSelectedPanel != selectedPanel)
        {
            SelectPanel();
        }

        if(lastPanel == true)
        {
            StartCoroutine(Fadeout(_image, _fadeSpeed));
            //Time.timeScale = 0;
            StartCoroutine("FadeInText");
            Debug.Log("Last Panel");
        }

    }

    void SelectPanel()
    {
        int i = 0;
        foreach (Transform panel in transform)
        {
            if (i == selectedPanel)
            {
                panel.gameObject.SetActive(true);
            }
            else
            {
                panel.gameObject.SetActive(false);
            }
            i++;
        }
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

    IEnumerator FadeInText()
    {
        //targetAlpha = 1.0f;
        Color curColor = TYText.color;
        while (Mathf.Abs(curColor.a - TYText.color.a) > 0.0001f)
        {
            Debug.Log(TYText.material.color.a);
            curColor.a = Mathf.Lerp(curColor.a, TYText.color.a, _fadeSpeed * Time.deltaTime);
            TYText.color = curColor;
            yield return null;
        }
    }
}