using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    public static int orderValue=121;
    public static int currentValue= 000 ;
    public static float[] orderTimers= { 0, 0, 0 };

    public bool getBoba;
    public bool getTea;
    public bool getMilk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddValue(int value)
    {
        currentValue += value;
    }
    public void ClearValue()
    {
        currentValue = 0;
    }
}
