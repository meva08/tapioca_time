using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkUIManager : MonoBehaviour
{
    public static MilkUIManager Instance;

    public GameObject milkOptionPrefab;
    public Transform optionPanel;

    private IngredientManager ingredientManager;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayMilkOptions()
    {
        // Clear existing UI options
        ClearOptions();

        // Get all MilkOption scripts in the scene
        Milk[] milkOptions = FindObjectsOfType<Milk>();

        // Display milk options (UI buttons, for example)
        foreach (Milk milkOption in milkOptions)
        {
            GameObject optionButton = Instantiate(milkOptionPrefab, optionPanel);
            optionButton.GetComponentInChildren<Text>().text = milkOption.ingredientName;
            optionButton.GetComponent<Button>().onClick.AddListener(() => OnMilkOptionClick(milkOption));
        }
    }

    private void OnMilkOptionClick(Milk selectedMilkOption)
    {
        // Handle the user's selection (e.g., use the selected milk option)
        Debug.Log("Selected Milk: " + selectedMilkOption.ingredientName);

        // Add the ingredient
        ingredientManager.AddIngredient(selectedMilkOption.ingredientID);

        // Optionally, clear the UI options after selection
        ClearOptions();
    }

    private void ClearOptions()
    {
        foreach (Transform child in optionPanel)
        {
            Destroy(child.gameObject);
        }
    }
}
