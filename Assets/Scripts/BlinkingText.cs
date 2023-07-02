using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public float Interval;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            if(text != null){
                text.enabled = false;
            }
            yield return new WaitForSeconds(Interval);
            if (text != null)
            {
                text.enabled = true;
            }
            yield return new WaitForSeconds(Interval);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(Blink());
    }
}
