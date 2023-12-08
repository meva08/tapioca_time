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
     public GameObject cam;

    PlayerController move; 


    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        move = controller.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            // show dialog box to shake
            move.enabled = false;
            if (Input.GetKeyDown(KeyCode.X))
            {
                
                points += 1;
                Debug.Log("points" + points);
                audiosource.PlayOneShot(click);
                
            }
            if (points >= 30)
            {
                // check the code and if match then pass and set bool = true
                    // show success box
                // else send the user on their way to try again
                    // show failure box 
                cam.GetComponent<playermoney>().addMoney(50);// add money
                hit = false;
                move.enabled = true;
            }
        }
    }
    
}
