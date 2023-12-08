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
                cam.GetComponent<playermoney> ().addMoney (50);
                points += 1;
                Debug.Log("points" + points);
                audiosource.PlayOneShot(click);
                // sound effect here
            }
            if (points >= 30)
            {
                // check the code and if match then pass and set bool = true
                    // show success box
                // else send the user on their way to try again
                    // show failure box 
                // add money
                hit = false;
                move.enabled = true;
            }
        }
    }
    
}
