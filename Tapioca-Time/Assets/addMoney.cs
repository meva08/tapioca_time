using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addReduce : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // change input to if order is correct
        if(Input.GetButtonDown("Fire1"))
        {
            cam.GetComponent<playermoney> ().addMoney (5);
        }
    }
}
