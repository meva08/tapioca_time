using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaStation : MonoBehaviour
{
    public IngredientManager ingredientManager;
    public BobaUIManager uiManager;
    public Sprite stationSprite;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Display boba options on the screen (UI)
            uiManager.DisplayBobaOptions();
        }
    }
}

