using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playermoney : MonoBehaviour
{
    public int money;
    public TMP_Text m_TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        m_TextComponent.text = money.ToString ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        m_TextComponent.text = money.ToString ();
    }
   
}
