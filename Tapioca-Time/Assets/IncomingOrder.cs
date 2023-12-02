using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public IngredientManager ingredientManager;
    public Sprite orderSprite;

    // Start the order system
    private void Start()
    {
        StartCoroutine(GenerateRandomOrder());
    }

    // Static method to get the name based on the ID
    public static string GetIngredientName(int id)
    {
        switch (id)
        {
            case 100: return "Regular Boba";
            case 200: return "Popping Boba";
            case 10: return "Black Tea";
            case 20: return "Thai Tea";
            case 1: return "Whole Milk";
            case 2: return "Skim Milk";
            default: return "Unknown Ingredient";
        }
    }

    // Coroutine to generate random orders
    private IEnumerator GenerateRandomOrder()
    {
        while (true)
        {
            // Generate a random order with one type of boba, tea, and milk each
            int randomBoba = GetRandomBobaID();
            int randomTea = GetRandomTeaID();
            int randomMilk = GetRandomMilkID();

            int order_value = randomBoba + randomTea + randomMilk;

            // Display the order 
            Debug.Log($"New Order: {GetIngredientName(randomBoba)}, {GetIngredientName(randomTea)}, {GetIngredientName(randomMilk)}");

            // Wait for some time before generating the next order
            yield return new WaitForSeconds(20f);
        }
    }

    // Get a random Boba ID
    private int GetRandomBobaID()
    {
        // Assuming you have two types of boba
        int randomBobaType = Random.Range(1, 3); // Randomly choose between 1 and 2

        if (randomBobaType == 1)
        {
            return 100; 
        }
        else
        {
            return 200; 
        }
    }


    // Get a random Tea ID
    private int GetRandomTeaID()
    {
        // Assuming you have two types of tea
        int randomTeaType = Random.Range(1, 3); // Randomly choose between 1 and 2

        if (randomTeaType == 1)
        {
            return 10; 
        }
        else
        {
            return 20; 
        }
    }

    // Get a random Milk ID
    private int GetRandomMilkID()
    {
        // Assuming you have two types of milk
        int randomMilkType = Random.Range(1, 3); // Randomly choose between 1 and 2

        if (randomMilkType == 1)
        {
            return 1; 
        }
        else
        {
            return 2; 
        }
    }
}

