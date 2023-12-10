using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countdown : MonoBehaviour
{
    // create float for the number of seconds
    public float timeStart = 120;
    // attach text component
    public TMP_Text m_TextComponent;
    void Start()
    {
        // convert timer number to string
        m_TextComponent.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // subtract time and update on-screen text
        timeStart -= Time.deltaTime;
        m_TextComponent.text = Mathf.Round(timeStart).ToString();
    }
}
