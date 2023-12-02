using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serveorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // this function should compare the two orders based on an input (mouse down default)
    private void OnMouseDown()
    {
        if (gameflow.orderValue==gameflow.currentValue)
        {
            Debug.Log("correct");
        }
    }
}
