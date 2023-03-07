using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickOffSound : MonoBehaviour
{
    public AudioSource kickoffAudio;
    public AudioSource swimmingAudio;
    private bool kickoffPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        swimmingAudio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0)
        {
            if (!kickoffAudio.isPlaying && kickoffPlaying)
            {
                kickoffAudio.Play();
                kickoffPlaying = false;
                StartCoroutine("Swimming");
            }

            else
            {
                kickoffPlaying = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            kickoffPlaying = true;
            kickoffAudio.Stop();
            swimmingAudio.Pause();
        }
    }


    IEnumerator Swimming()
    {
        yield return new WaitForSeconds(0.7f);
        swimmingAudio.Play();
    }
}
