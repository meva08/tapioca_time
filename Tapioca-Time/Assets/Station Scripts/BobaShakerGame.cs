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
            ServeOrder(OrderSystem.current_order, Game_manager.currentValue);
        }
    }

    public void ServeOrder(int order, int playerorder)
    {
        //controller.GetComponent(PlayerController).enabled = false;
            if (order==playerorder)
                {
                    Debug.Log("correct");
                }
                else
                {
                    Debug.Log("not right");
                }
    }
    
}
