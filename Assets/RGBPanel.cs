using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RGBPanel : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public bool activate = false;

    public float gameTimer = 0f;
    private float Timer = 0f;

    private void Start()
    {
        image.enabled = false;
        text.enabled = false;
    }

    private void Update()
    {
        if (activate)
        {
            image.enabled = true;
            text.enabled = true;

            image.color = new Color(0.5f * Mathf.Sin(Timer), Mathf.Cos(Timer), 2f * Mathf.Sin(Timer), 0.5f);
            Timer += Time.deltaTime;
            text.text = "Out of Bubble! \n You survived " + gameTimer + " seconds";
        }
        else
        {
            gameTimer += Time.deltaTime;
        }
    }

}
