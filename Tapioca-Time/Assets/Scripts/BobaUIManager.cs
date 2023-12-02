using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaUIManager : MonoBehaviour
{
    public static BobaUIManager Instance;

    public GameObject bobaOptionPrefab;
    public Transform optionPanel;
    public Image stationImage;

    private IngredientManager ingredientManager;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayBobaOptions()
    {
        // Clear existing UI options
        ClearOptions();

        // Set the station sprite (if needed)
        // stationImage.sprite = ...

        // Get all BobaOption scripts in the scene
        Boba[] bobaOptions = FindObjectsOfType<Boba>();

        // Display boba options (UI buttons, for example)
        foreach (Boba bobaOption in bobaOptions)
        {
            GameObject optionButton = Instantiate(bobaOptionPrefab, optionPanel);
            optionButton.GetComponentInChildren<Text>().text = bobaOption.ingredientName;

            // Add a listener to the button to handle the click event
            optionButton.GetComponent<Button>().onClick.AddListener(() => OnBobaOptionClick(bobaOption));
        }
    }

    private void OnBobaOptionClick(Boba selectedBobaOption)
    {
        // Handle the user's selection (e.g., use the selected boba option)
        Debug.Log("Selected Boba: " + selectedBobaOption.ingredientName);

        // Add the ingredient
        ingredientManager.AddIngredient(selectedBobaOption.ingredientID);

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

