using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThaiTeaStation : MonoBehaviour
{
    public float displayTime = 2.0f; // variables for display time of text
    float timerDisplay;

    public GameObject dialogBox; // set variables for the text UI objects
    public GameObject failBox;
    public Image thaiTea; // reference UI object

    public GameObject flow; // reference gameflow game object 

    AudioSource audioSource; // define variables for audio 
    public AudioClip teaGet;
    public AudioClip error;


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false); // set all UI elements as false at start
        failBox.SetActive(false);
        thaiTea.enabled = false;

        timerDisplay = -1.0f; // set timer to negative
        audioSource = GetComponent<AudioSource>(); // reference AudioSource
    }
    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0) // if timer is positive, then count down
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0) // if timer reaches 0, disable text UI
            {
                dialogBox.SetActive(false);
                failBox.SetActive(false);
            }
        }
    }
    public void DisplayDialog() // function for station 
    {
        timerDisplay = displayTime; // once invoked, set display time to positive value
        Game_manager order = flow.GetComponent<Game_manager>(); // reference the script of gameflow

        if (order.getTea == false) // if you don't have Boba, then move on
        {
            dialogBox.SetActive(true); // show text 

            order.AddValue(20); // add to currentValue

            order.getTea = true; // set variable to true

            audioSource.PlayOneShot(teaGet); // play sound effect

            thaiTea.enabled = true; // display boba UI icon

        }
        else
        {
            failBox.SetActive(true); // show text -> unable to get more boba

            audioSource.PlayOneShot(error); // play sound effect
        }
    }
}