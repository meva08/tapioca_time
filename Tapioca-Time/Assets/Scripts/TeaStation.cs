using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaStation : MonoBehaviour
{
    public TeaUIManager uiManager;
    public Sprite stationSprite;

    private const int BobaThreshold = 100;

    private IngredientManager ingredientManager;

    private void Start()
    {
        // Get the IngredientManager component from the current GameObject or another GameObject in the scene
        ingredientManager = GetComponent<IngredientManager>();

        // Check if ingredientManager is null and handle the situation if needed
        if (ingredientManager == null)
        {
            Debug.LogError("IngredientManager component not found on TeaStation GameObject.");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the sum of collected ingredient IDs is greater than the threshold (BobaThreshold)
            if (ingredientManager.TotalSum >= BobaThreshold)
            {
                // Display tea options on the screen (UI)
                uiManager.DisplayTeaOptions();
            }
            else
            {
                // Display a message or perform some action to inform the player
                Debug.Log("You need to collect more preceding ingredients (Boba) first.");
            }
        }
    }
}




