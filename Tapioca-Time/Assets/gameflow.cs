using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    public static int orderValue = 121;
    public static int currentValue = 000 ;

    public GameObject OrderSystem;

    OrderSystem ordersystem;
    public static float[] orderTimers= { 0, 0, 0 };

    public bool getBoba;
    public bool getTea;
    public bool getMilk;
    // Start is called before the first frame update
    void Start()
    {
        ordersystem = OrderSystem.GetComponent<OrderSystem>();
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
    public void ClearValue()
    {
        currentValue = 0;
    }
    public bool Comparison()
    {
        if (ordersystem.order_value == currentValue)
        {
            Debug.Log ("true");
            return true;
        }
        else 
        {
            Debug.Log ("false");
            return false; 
        }
    }
}
