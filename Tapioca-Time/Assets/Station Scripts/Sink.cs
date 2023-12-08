using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Game_manager order = flow.GetComponent<Game_manager>(); // reference the script of gameflow

        if (!order.getMilk && !order.getTea && !order.getBoba) // if you don't have anything in cup, error message
        {
            failBox.SetActive(true); // show text
            audioSource.PlayOneShot(error); // play sound effect
            

        }
        else
        {
            dialogBox.SetActive(true); // show text 
            //ingredientUI.SetActive(false); 

            foreach (Transform child in ingredientUI.transform)
            {
                // Check if the child has an Image component
                Image imageComponent = child.GetComponent<Image>();

                // If the child has an Image component, deactivate it
                if (imageComponent != null)
                {
                    imageComponent.enabled = false; // Set image component inactive
                }
            }



                order.getMilk = false; // set variable to false - cup is empty
            order.getTea = false;
            order.getBoba = false;

            order.ClearValue();

            audioSource.PlayOneShot(dump); // play sound effect

            


        }
        
    }
}

