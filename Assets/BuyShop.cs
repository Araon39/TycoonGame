using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyShop : MonoBehaviour
{
    // Количество магазинов
    public int shopAmount = 1;

    // Текстовый элемент UI для отображения количества магазинов
    [SerializeField] private Text shopAmountText;

    // Ссылка на скрипт TAKEMoney
    private TAKEMoney takeMoneyScript;

    // Текстовый элемент UI для отображения стоимости покупки магазина
    [SerializeField] private Text costButtonShopBuy;

    // Стоимость покупки магазина
    public int costShop = 50;

    private void Start()
    {
        // Находим компонент TAKEMoney на объекте "GameManager"
        takeMoneyScript = GameObject.Find("GameManager").GetComponent<TAKEMoney>();

        // Устанавливаем текст кнопки покупки магазина
        costButtonShopBuy.text = "Buy" + costShop.ToString() + " $";
    }

    public void Buy()
    {
        // Проверяем, достаточно ли денег для покупки магазина
        if (takeMoneyScript.totalMoney >= costShop)
        {
            // Уменьшаем общее количество денег на стоимость магазина
            takeMoneyScript.totalMoney -= costShop;

            // Увеличиваем стоимость следующего магазина
            costShop *= 2;

            // Обновляем текст кнопки покупки магазина
            costButtonShopBuy.text = "Buy" + costShop.ToString() + " $";

            // Обновляем текстовое поле с количеством денег
            takeMoneyScript.moneyText.text = takeMoneyScript.totalMoney.ToString();

            // Увеличиваем количество магазинов
            shopAmount += 1;

            // Обновляем текстовое поле с количеством магазинов
            shopAmountText.text = shopAmount.ToString();
        }
    }
}
