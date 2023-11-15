using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyShop : MonoBehaviour
{
    public int shopAmount = 1;
    [SerializeField] private Text shopAmountText;
    
    private TAKEMoney takeMoneyScript;
    
    [SerializeField] private Text costButtonShopBuy;
    public int costShop = 50;

    private void Start()
    {
        takeMoneyScript = GameObject.Find("GameManager").GetComponent<TAKEMoney>();
        costButtonShopBuy.text = "Buy" + costShop.ToString() + " $";
    }

    public void Buy()
    {
        if (takeMoneyScript.totalMoney >= costShop)
        {
            takeMoneyScript.totalMoney -= costShop;
            costShop *= 2;
            
            costButtonShopBuy.text = "Buy" + costShop.ToString() + " $";
            takeMoneyScript.moneyText.text = takeMoneyScript.totalMoney.ToString();
            
            shopAmount += 1;
            shopAmountText.text = shopAmount.ToString();
        }
        
    }
}
