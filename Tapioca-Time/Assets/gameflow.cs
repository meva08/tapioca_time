using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    public static int orderValue=121;
    public static int currentValue= 000 ;
    public static float[] orderTimers= { 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CurrentValue = " + currentValue);
    }
    public void AddValue(int value)
    {
        currentValue += value;
    }
}
