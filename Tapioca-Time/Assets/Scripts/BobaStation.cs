using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BobaStation : MonoBehaviour
{
    public IngredientManager ingredientManager;
    public BobaUIManager uiManager;
    public Sprite stationSprite;

    public PlayerController player;

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player has collided");

        player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
             uiManager.DisplayBobaOptions();
        }

       
        // if (other.CompareTag("Player"))
        // {
        //     // Display boba options on the screen (UI)
        //     uiManager.DisplayBobaOptions();
        // }
    }
}

