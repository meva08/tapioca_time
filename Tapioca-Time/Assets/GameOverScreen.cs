using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text outcome;
    public countdown timer;
    public playermoney money;

    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
        // Attempt to get the countdown component from the same GameObject
        timer = timer.GetComponent<countdown>();

        // Check if the countdown component is found
        if (timer == null)
        {
            Debug.LogError("Countdown component not found!");
        }

        // Attempt to get the playermoney component from the same GameObject
        money = money.GetComponent<playermoney>();

        // Check if the playermoney component is found
        if (money == null)
        {
            Debug.LogError("Playermoney component not found!");
        }
    }

    void Update()
    {
        // Check if timer and money are properly assigned
        if (timer == null || money == null)
        {
            Debug.LogError("Timer or Money is not properly assigned!");
            return;
        }

        // Check if the timer has reached zero
        if (timer.timeStart <= 0)
        {

            // Set the game over screen active
            canvas.SetActive(true);

            Debug.Log("Game Over!");

            // Check the player's money and update the outcome text
            if (money.money >= 500)
            {
                outcome.text = "A+! You're amazing!";
            }
            else if (money.money >= 400)
            {
                outcome.text = "A! Solid!";
            }
            else if (money.money >= 300)
            {
                outcome.text = "B! Pretty good!";
            }
            else if (money.money >= 200)
            {
                outcome.text = "C! Ok.";
            }
             else if (money.money >= 100)
            {
                outcome.text = "D! Good effort!";
            }
            else
            {
                outcome.text = "Uh, did you even try?";
            }



            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("SampleScene");
                Debug.Log("Button Clicked");
            }
        }
    }
   
}

