using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingSequence : MonoBehaviour
{
    public int selectedPanel = 0;
    public Image endingPanel;
    public Image TYText;
    public Image FPText;
    public Image ZIndicator;
    private bool lastPanel = false;
    public AudioSource endTheme;

    void Start()
    {
        ZIndicator.enabled = true;
        TYText.enabled = false;
        FPText.enabled = false;
        endTheme.loop = true;
        endTheme.Play();
        SelectPanel();
    }

    void Update()
    {
        int previousSelectedPanel = selectedPanel;

        if (Input.GetKeyDown(KeyCode.X) && Time.timeScale > 0)
        {
            //If last panel
            if (selectedPanel == 9)
            {
                ZIndicator.enabled = false;
                lastPanel = true;
            }

            else
            {
                selectedPanel++;
            }
        }

        if (previousSelectedPanel != selectedPanel && lastPanel == false)
        {
            SelectPanel();
        }

        if(lastPanel == true)
        {
            TYText.enabled = true;
            FPText.enabled = true;
            StartCoroutine(FadeOutImage(true, endingPanel));
            StartCoroutine(FadeOutImage(true, TYText));
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

    IEnumerator FadeOutImage(bool fadeAway, Image img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 5; i >= 0; i -= Time.deltaTime)
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

        SceneManager.LoadScene("Title_Screen");
    }

    //IEnumerator FadeInText()
    //{
    //    //targetAlpha = 1.0f;
    //    Color curColor = TYText.color;
    //    while (Mathf.Abs(curColor.a - TYText.color.a) > 0.0001f)
    //    {
    //        Debug.Log(TYText.material.color.a);
    //        curColor.a = Mathf.Lerp(curColor.a, TYText.color.a, _fadeSpeed * Time.deltaTime);
    //        TYText.color = curColor;
    //        yield return null;
    //    }
    //}
}