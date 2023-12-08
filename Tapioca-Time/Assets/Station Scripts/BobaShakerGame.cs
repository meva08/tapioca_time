using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BobaShakerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hit; // define variables 
    public int points;
    public GameObject controller; // access other objects 

    public GameObject gameflow;
    
    public AudioClip click; // audio clips
    public AudioClip error;
    public AudioClip cash; 
     public GameObject cam;

    PlayerController move; //define components
    AudioSource audiosource;

    gameflow order; 

    public GameObject shake; // textboxes
    public GameObject results; 
    public TMP_Text resulttext;

    public GameObject ingredientUI;

    

    public float displayTime = 2.0f; // variables for display time of text
    float timerDisplay;



    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        move = controller.GetComponent<PlayerController>();
        order = gameflow.GetComponent<gameflow>();
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

        if (hit == true)
        {
            if (order.getMilk && order.getTea && order.getBoba)
            {
                shake.SetActive(true); // show dialog box to shake
                move.enabled = false;
                if (Input.GetKeyDown(KeyCode.X))
                {
                    
                    points += 1;
                    Debug.Log("points" + points);
                    audiosource.PlayOneShot(click);
                    
                }
                if (points >= 30)
                {
                    // if (check is successful)
                    //check the code and if match then pass 
                        
                    
                        cam.GetComponent<playermoney>().addMoney(50);// add money
                        shake.SetActive(false); // disable shake instructions
                        
                        timerDisplay = displayTime;
                        resulttext.SetText("Success!");
                        results.SetActive(true); // show success box
                        // and set bool = true for next order

                        audiosource.PlayOneShot(cash);

                    // else send the user on their way to try again
                        // resulttext.setText("Not the right order...")
                        // results.setActive(true);

                    hit = false;
                    move.enabled = true;
                    order.getMilk = false; // set variable to false - cup is empty
                    order.getTea = false;
                    order.getBoba = false;
                    points = 0; 
                    order.ClearValue();

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

                    
                }
                
            }
            else
            {
                timerDisplay = displayTime;
                resulttext.SetText("You don't have all the ingredients!");
                results.SetActive(true);
                audiosource.PlayOneShot(error);
                hit = false;
            }
        }
    }
    
}
