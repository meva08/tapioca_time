using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkFridge : MonoBehaviour
{
    public MilkUIManager uiManager;
    public Sprite stationSprite;

    private IngredientManager ingredientManager;

    private void Start()
    {
        // Get the IngredientManager component from the current GameObject or another GameObject in the scene
        ingredientManager = GetComponent<IngredientManager>();

        // Check if ingredientManager is null and handle the situation if needed
        if (ingredientManager == null)
        {
            Debug.LogError("IngredientManager component not found on MilkFridge GameObject.");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player put the tea first
            if (ingredientManager.TotalSum == 110 |ingredientManager.TotalSum == 120 |ingredientManager.TotalSum == 210 | ingredientManager.TotalSum == 220)
            {
                // Display tea options on the screen (UI)
                uiManager.DisplayMilkOptions();
            }
            else
            {
                // Display a message or perform some action to inform the player
                Debug.Log("You need to collect more preceding ingredients (Tea) first.");
            }
        }
    }
}
