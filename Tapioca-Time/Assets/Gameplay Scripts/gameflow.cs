using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    // create placeholders for the order value and current values
    public static int orderValue = 121;
    public static int currentValue = 000 ;
    public GameObject OrderSystem; 
    OrderSystem ordersystem;
    // create three bool variables to indicate ingredient possession
    public bool getBoba; 
    public bool getTea;
    public bool getMilk;
    void Start()
    {
        // get the contents of OrderSystem as a game object
        ordersystem = OrderSystem.GetComponent<OrderSystem>();
    }
    // add values to the orders
    public void AddValue(int value)
    {
        currentValue += value;
    }
    // get rid of order value
    public void ClearValue()
    {
        currentValue = 0;
    }
    // compare the value of two orders
    public bool Comparison()
    {
        // return true if the order values are equal
        if (ordersystem.order_value == currentValue)
        {
            return true;
        }
        else 
        {
            return false; 
        }
    }
}
