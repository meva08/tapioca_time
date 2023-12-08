using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_manager : MonoBehaviour
{
    public static Game_manager Instance { get; private set; }
    // number of seconds in timer
    public float timeStart = 120;
    // create text for timer
    public TMP_Text m_TextComponent;
    // values of the shown order and current value of player order
    public static int orderValue=121;
    public static int currentValue= 000 ;
    // check if Instance is already created to avoid duplicates
    private void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        
    }

    void Start()
    {
        m_TextComponent.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // start the timer
        timeStart -= Time.deltaTime;
        // convert timer numbers into string
        m_TextComponent.text = Mathf.Round(timeStart).ToString();
    }
    private void OnMouseDown()
    {
        // compare orders, current input is mouse click
        if (orderValue==currentValue)
        {
            Debug.Log("correct");
        }
    }
}

