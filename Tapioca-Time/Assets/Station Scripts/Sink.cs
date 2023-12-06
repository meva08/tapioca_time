using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public float displayTime = 2.0f; // variables for display time of text
    float timerDisplay;

    public GameObject dialogBox; // set variables for the text UI objects
    public GameObject failBox;
    public GameObject ingredientUI;
   

    public GameObject flow; // reference gameflow game object 

    AudioSource audioSource; // define variables for audio 
    public AudioClip dump;
    public AudioClip error;


    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false); // set all UI elements as false at start
        failBox.SetActive(false);
       

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

        if (!order.getMilk && !order.getTea && !order.getBoba) // if you don't have anything in cup, error message
        {
            failBox.SetActive(true); // show text
            audioSource.PlayOneShot(error); // play sound effect
            

        }
        else
        {
            dialogBox.SetActive(true); // show text 
            ingredientUI.SetActive(false); 

            

            order.getMilk = false; // set variable to false - cup is empty
            order.getTea = false;
            order.getMilk = false;

            order.ClearValue();

            audioSource.PlayOneShot(dump); // play sound effect

            


        }
    }
}

