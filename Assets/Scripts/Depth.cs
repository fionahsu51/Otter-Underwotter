using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Depth : MonoBehaviour
{

    public Transform target;
    public TMP_Text depthText;
    int playerDepth;
    int previousPlayerDepth;
    string feet_string = " m";

    void Start()
    {
        playerDepth = 5;
    }

    void Update()
    {
        previousPlayerDepth = playerDepth;
        playerDepth = (int)target.position.y;

        //Optimizing the starting "depth" taken from the player's y-axis
        if(playerDepth <= 0 && playerDepth > -5)
        {
            playerDepth = 5;
        }

        //No negative numbers
        else if(playerDepth <= -5)
        {
            playerDepth *= -1;
        }

        depthText.text = playerDepth.ToString();
        depthText.text += feet_string;
    }
}