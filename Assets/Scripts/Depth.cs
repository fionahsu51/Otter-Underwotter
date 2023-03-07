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
        playerDepth = 0;
    }

    void Update()
    {
        playerDepth = (int)target.position.y;
        depthText.text = playerDepth.ToString();
    }
}