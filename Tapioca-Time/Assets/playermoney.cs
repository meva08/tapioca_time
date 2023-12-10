using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playermoney : MonoBehaviour
{
    // create money variable and text component
    public int money;
    public TMP_Text m_TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        // set money to 0
        money = 0;
        m_TextComponent.text = money.ToString ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // add the amount of money inputted into the function
    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        m_TextComponent.text = money.ToString ();
    }
   
}
