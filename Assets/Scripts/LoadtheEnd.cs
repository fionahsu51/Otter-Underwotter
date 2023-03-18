using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadtheEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadEnd()
    {
        Debug.Log("end");
        yield return new WaitForSeconds(3f);
        Debug.Log("ending");
        SceneManager.LoadScene("Ending");
    }
}
