using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderSystem : MonoBehaviour
{
    public GameObject dialogBox;
    public TMP_Text debugText;
    public bool orderCompleted;
    public int order_value;
    public static int current_order;

    // Start the order system
    private void Start()
    {
        // Generate the first order
        current_order = GenerateRandomOrder();
    }

    // Continue generating orders as the user completes them
    private void Update()
    {
        if(orderCompleted)
            {
                orderCompleted = false;
                current_order = GenerateRandomOrder();
            }
    }


    // Static method tox get the name based on the ID
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

    // Generate random orders
    public int GenerateRandomOrder()
    {
            // Generate a random order with one type of boba, tea, and milk each
            int randomBoba = GetRandomBobaID();
            int randomTea = GetRandomTeaID();
            int randomMilk = GetRandomMilkID();

            order_value = randomBoba + randomTea + randomMilk;

            // Display the order 
            Debug.Log($"New Order: {GetIngredientName(randomBoba)}, {GetIngredientName(randomTea)}, {GetIngredientName(randomMilk)}");

            // Update the UI Text element with the Debug log text
            Update();

            void Update() 
            {
            debugText.SetText($"New Order: \r\n {GetIngredientName(randomBoba)} \r\n {GetIngredientName(randomTea)} \r\n {GetIngredientName(randomMilk)}");
            }
            return order_value;
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

