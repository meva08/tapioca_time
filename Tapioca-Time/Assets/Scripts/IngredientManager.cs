using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IngredientManager : MonoBehaviour
{
    public List<int> collectedIngredientIDs = new List<int>();

    public void AddIngredient(int ingredientID)
    {
        // Check if the type of ingredient is not already collected
        if (!collectedIngredientIDs.Exists(i => i.GetType() == ingredientID.GetType()))
        {
            collectedIngredientIDs.Add(ingredientID);
            // Ingredient added successfully
        }
    }

    // Property to get the total sum
    public int TotalSum
    {
        get
        {
            return CalculateTotalSum();
        }
    }

    // Method to calculate the total sum
    public int CalculateTotalSum()
    {
        int sum = 0;
        foreach (int ingredientID in collectedIngredientIDs)
        {
            sum += ingredientID;
        }
        return sum;
    }


    public bool IsCorrectOrder(int correctOrderSum)
    {
        // Calculate the sum of collected ingredient IDs
        int sum = 0;
        foreach (int ingredientID in collectedIngredientIDs)
        {
            sum += ingredientID;
        }
        // Compare the sum with the provided correct order sum
        return sum == correctOrderSum;
    }

    public void ClearIngredients()
    {
        collectedIngredientIDs.Clear();
    }
}

