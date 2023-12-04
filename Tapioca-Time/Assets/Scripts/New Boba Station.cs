using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBobaStation : MonoBehaviour
{
    // Connect to UI Object?
    // public variables 
    // Start is called before the first frame update
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
    void Start()
    {
        dialogBox.SetActive(false);
      
        timerDisplay = -1.0f;

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
        dialogBox.SetActive(true);
    }
}