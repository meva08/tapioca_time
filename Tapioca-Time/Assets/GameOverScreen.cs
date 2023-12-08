using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text outcome;
    public countdown timer;
    public playermoney money;

    private void Start()
    {
        gameObject.SetActive(false);
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

    private void Update()
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
            gameObject.SetActive(true);

            Debug.Log("Game Over!");

            // Check the player's money and update the outcome text
            if (money.money >= 200)
            {
                outcome.text = "You won!";
            }
            else
            {
                outcome.text = "You lost...";
            }
        }
    }
}

