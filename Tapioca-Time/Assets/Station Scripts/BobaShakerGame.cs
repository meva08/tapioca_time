using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaShakerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hit;
    public int points;
    public GameObject controller;
    AudioSource audiosource;
    public AudioClip click;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            //controller.GetComponent(PlayerController).enabled = false;
            if (Input.GetKeyDown(KeyCode.X))
            {
                points += 1;
                Debug.Log("points" + points);
                audiosource.PlayOneShot(click);
                // sound effect here
            }
            if (points >= 30)
            {
                hit = false;
                //controller.GetComponent(PlayerController).enabled = true;
            }
        }
    }
    
}
