using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkimFridge : MonoBehaviour
{
    public float displayTime = 2.0f; // variables for display time of text
    float timerDisplay;

    public GameObject dialogBox; // set variables for the text UI objects
    public GameObject failBox;
    public Image skimMilk; // reference UI object

    public GameObject flow; // reference gameflow game object 

    AudioSource audioSource; // define variables for audio 
    public AudioClip milkGet;
    public AudioClip error;


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false); // set all UI elements as false at start
        failBox.SetActive(false);
        skimMilk.enabled = false;

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
        gameflow order = flow.GetComponent<gameflow>(); // reference the script of gameflow

        if (order.getMilk == false) // if you don't have Boba, then move on
        {
            dialogBox.SetActive(true); // show text 

            order.AddValue(2); // add to currentValue

            order.getMilk = true; // set variable to true

            audioSource.PlayOneShot(milkGet); // play sound effect

            skimMilk.enabled = true; // display boba UI icon

        }
        else
        {
            failBox.SetActive(true); // show text -> unable to get more boba

            audioSource.PlayOneShot(error); // play sound effect
        }
    }
}
