using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countdown : MonoBehaviour
{
    public float timeStart = 120;
    public TMP_Text m_TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        m_TextComponent.text = Mathf.Round(timeStart).ToString();
    }
}
