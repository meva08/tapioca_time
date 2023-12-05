using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBobaStation : MonoBehaviour
{   
    // Start is called before the first frame update
 
    public float displayTime = 2.0f;
    public GameObject dialogBox;
    public GameObject failBox;

    public GameObject flow; // reference gameflow game object 

    public bool GetBoba; // wait on Maryeva for centralized bool variable? 

    AudioSource audioSource;
    public AudioClip boba; 

    // Leave room for Maryeva's code for order system -> you already have this
    float timerDisplay;

   

    void Start()
    {
        dialogBox.SetActive(false);
        failBox.SetActive(false);

        timerDisplay = -1.0f;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
                failBox.SetActive(false);
            }
        }


        // if getboba is false:
        // display text once x is pressed
        // add to a public varaible 
        // getboba set to true
        // set another UI thing to true?
        //else
        // display text that boba is already gotten 
    }
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        if (GetBoba == false)
        {
            dialogBox.SetActive(true);

            gameflow order = flow.GetComponent<gameflow>();

            order.AddValue(100);

            GetBoba = true;

            audioSource.PlayOneShot(boba);



           

        }
        else
        {
            failBox.SetActive(true); 
        }
    }
}
