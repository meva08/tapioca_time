using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaShakerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool variable;
    public int points;
    public GameObject controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (variable == true)
        {
            // controller. GetComponent(YourScript).enabled = false;
            if (Input.GetKeyDown(KeyCode.X))
            {
                points += 1;
                // sound effect here
            }
            if (points >= 30)
            {
                variable = false;
                // controller. GetComponent(YourScript).enabled = true;
            }
        }
    }
    
}
