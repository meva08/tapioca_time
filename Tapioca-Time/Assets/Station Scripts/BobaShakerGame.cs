using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BobaShakerGame : MonoBehaviour
{

    public bool hit; // did player interact with station?
    public int points; // how many clicks of X?

    // access other objects 
    public GameObject controller; 
    public GameObject gameflow;
    public GameObject cam;
    public GameObject ingredientUI;
    public GameObject OrderSystem;

    // audio clips

    public AudioClip click; 
    public AudioClip error;
    public AudioClip cash;

    //define components 
    PlayerController move; 
    AudioSource audiosource;
    gameflow order; 
    OrderSystem ordersystem;

    // textboxes and text
    public GameObject shake; 
    public GameObject results; 
    public TMP_Text resulttext;
    public float displayTime = 2.0f; // variables for display time of text
    float timerDisplay;
    bool success;

    void Start()
    {
        // get all the components we need - create instances
        audiosource = GetComponent<AudioSource>();
        move = controller.GetComponent<PlayerController>();
        order = gameflow.GetComponent<gameflow>();
        ordersystem = OrderSystem.GetComponent<OrderSystem>();
        timerDisplay = -1.0f; // set timer to negative  
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0) // if timer is positive, then count down
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0) // if timer reaches 0, disable text UI
            {
                results.SetActive(false);
            }
        }

        if (hit == true) // if player interacts with station: 
        {
            if (order.getMilk && order.getTea && order.getBoba) // if you have everything
            {
                shake.SetActive(true); // show dialog box to shake
                move.enabled = false;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    
                    points += 1; // everytime X is clicked, + 1
                    Debug.Log("points" + points);
                    audiosource.PlayOneShot(click);
                    
                }
                if (points >= 30) // once you click 30 times, run function
                {
                    if (order.Comparison() == true) // if your order matches currentorder, continue
                    {       
                        cam.GetComponent<playermoney>().addMoney(50);// add money
                        shake.SetActive(false); // disable shake instructions
                        success = true;
                        ordersystem.orderCompleted = true; // tell order generator to make new order
                        audiosource.PlayOneShot(cash); // play sound
                    }
                    else // otherwise set to false
                    {
                        shake.SetActive(false); // disable shake instructions
                        success = false;
                        audiosource.PlayOneShot(error);
                    }

                    // else send the user on their way to try again
                        // resulttext.setText("Not the right order...")
                        // results.setActive(true);

                    hit = false;
                    move.enabled = true;
                    order.getMilk = false; // set variable to false - cup is empty
                    order.getTea = false;
                    order.getBoba = false;
                    points = 0; 
                    order.ClearValue(); // clear your current cup 

                    foreach (Transform child in ingredientUI.transform) // clear UI
                    {
                        // Check if the child has an Image component
                        Image imageComponent = child.GetComponent<Image>();

                        // If the child has an Image component, deactivate it
                        if (imageComponent != null)
                        {
                            imageComponent.enabled = false; // Set image component inactive
                        }
                    }                    
                }              
            }
            else
            {
                
               if (success == true) // show this text if successful delivery
               {
                timerDisplay = displayTime;
                resulttext.SetText("Delivered! Go do another order!");
                results.SetActive(true);
               }
               else // otherwise show other message
               {
                timerDisplay = displayTime;
                resulttext.SetText("Wrong order! Try again!");
                results.SetActive(true);
                audiosource.PlayOneShot(error);
               }
               hit = false;        
            }
        }
    }
    
}
