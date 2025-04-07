using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RainbowText : MonoBehaviour
{
    private TextMeshProUGUI tc;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        tc = GetComponent<TextMeshProUGUI>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > 0.5f)
        {
            startTime = Time.time;
            tc.color = RandonmizeColor();
        }
    }

    private Color RandonmizeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b, 1f);
    }
}