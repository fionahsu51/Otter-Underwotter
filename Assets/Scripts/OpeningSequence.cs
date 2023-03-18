using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpeningSequence : MonoBehaviour
{
    public Image panel1;
    public Image panel2;
    public Image panel3;
    public Image panel4;
    public Image panel5;
    public Image panel6;
    public Image panel7;
    public Image panel8;
    public Image panel9;
    public Image panel10;
    public Image panel11;
    public Image panel12;
    public Image panel13;
    public Image panel14;
    public Image panel15;
    public Image panel16;

    public int selectedPanel = 2;
    private bool lastPanel = false;
    public Image XIndicator;
    public float _fadeSpeed = 0.05f;
    //public Image _image;

    void Start()
    {
        panel1.enabled = true;
        panel2.enabled = false;
        panel3.enabled = false;
        panel4.enabled = false;
        panel5.enabled = false;
        panel6.enabled = false;
        panel7.enabled = false;
        panel8.enabled = false;
        panel9.enabled = false;
        panel10.enabled = false;
        panel11.enabled = false;
        panel12.enabled = false;
        panel13.enabled = false;
        panel14.enabled = false;
        panel15.enabled = false;
        panel16.enabled = false;
    }

    void Update()
    {
        int previousSelectedPanel = selectedPanel;
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(selectedPanel == 2)
            {
                panel1.enabled = false;
                panel2.enabled = true;
            }

            else if(selectedPanel == 3)
            {
                panel3.enabled = true;
            }

            else if (selectedPanel == 4)
            {
                panel4.enabled = true;
                panel2.enabled = false;
                panel3.enabled = false;
            }

            else if (selectedPanel == 5)
            {
                panel5.enabled = true;
            }

            else if (selectedPanel == 6)
            {
                panel6.enabled = true;
            }

            else if (selectedPanel == 7)
            {
                panel7.enabled = true;
            }

            else if (selectedPanel == 8)
            {
                panel8.enabled = true;
                panel4.enabled = false;
                panel5.enabled = false;
                panel6.enabled = false;
                panel7.enabled = false;
            }

            else if (selectedPanel == 9)
            {
                panel9.enabled = true;
            }

            else if (selectedPanel == 10)
            {
                panel10.enabled = true;
            }

            else if (selectedPanel == 11)
            {
                panel11.enabled = true;
            }

            else if (selectedPanel == 12)
            {
                panel12.enabled = true;
            }

            else if (selectedPanel == 13)
            {
                panel8.enabled = false;
                panel9.enabled = false;
                panel10.enabled = false;
                panel11.enabled = false;
                panel12.enabled = false;
                panel13.enabled = true;
            }

            else if (selectedPanel == 14)
            {
                panel14.enabled = true;
            }

            else if (selectedPanel == 15)
            {
                panel15.enabled = true;
            }

            else if (selectedPanel == 16)
            {
                panel16.enabled = true;
                XIndicator.enabled = false;
                lastPanel = true;
            }

            selectedPanel++;
        }

        if (lastPanel == true)
        {
            StartCoroutine(FadeOutImage(true, panel13));
            StartCoroutine(FadeOutImage(true, panel14));
            StartCoroutine(FadeOutImage(true, panel15));
            StartCoroutine(FadeOutImage(true, panel16));
            Debug.Log("Last Panel");
        }
    }

    IEnumerator FadeOutImage(bool fadeAway, Image img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 4f; i >= 0; i -= Time.deltaTime)
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

        SceneManager.LoadScene("Instructions");
    }
}