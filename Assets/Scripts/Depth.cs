using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Depth : MonoBehaviour
{

    public Transform target;
    public TMP_Text depthText;
    int playerDepth;

    void Start()
    {
        playerDepth = 5;
    }

    void Update()
    {
        playerDepth = (int)target.position.y;

        if(playerDepth > 0)
        {
            playerDepth = 5;
        }

        //No negative numbers
        else if(playerDepth < 0)
        {
            playerDepth *= -1;
        }
        depthText.text = playerDepth.ToString();
    }
}