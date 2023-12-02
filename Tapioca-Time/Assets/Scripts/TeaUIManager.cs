using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaUIManager : MonoBehaviour
{
    public static TeaUIManager Instance;

    public GameObject teaOptionPrefab;
    public Transform optionPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayTeaOptions()
    {
        // Clear existing UI options
        ClearOptions();

        // Get all TeaOption scripts in the scene
        Tea[] teaOptions = FindObjectsOfType<Tea>();

        // Display tea options (UI buttons, for example)
        foreach (Tea teaOption in teaOptions)
        {
            GameObject optionButton = Instantiate(teaOptionPrefab, optionPanel);
            optionButton.GetComponentInChildren<Text>().text = teaOption.ingredientName;
            optionButton.GetComponent<Button>().onClick.AddListener(() => OnTeaOptionClick(teaOption));
        }
    }

    private void OnTeaOptionClick(Tea selectedTeaOption)
    {
        // Handle the user's selection (e.g., use the selected tea option)
        Debug.Log("Selected Tea: " + selectedTeaOption.ingredientName);

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

