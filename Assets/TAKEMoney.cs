using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TAKEMoney : MonoBehaviour
{
    // Базовое количество денег, добавляемое каждый цикл
    [SerializeField] private int baseCount = 5;

    // Общее количество денег
    public float totalMoney = 2;

    // Текстовый элемент UI для отображения количества денег
    public Text moneyText;

    // Ссылка на компонент BuyShop
    private BuyShop _buyShop;

    // Слайдер для отображения прогресса
    [SerializeField] private Slider progressSlider;

    // Время ожидания между циклами
    private float _storeTimer = 2f;

    // Текущее время, прошедшее с начала цикла
    [SerializeField] private float _curentTime;

    void Start()
    {
        // Находим компонент BuyShop на объекте "NewStandPanel"
        _buyShop = GameObject.Find("NewStandPanel").GetComponent<BuyShop>();

        // Запускаем корутину NewStand
        StartCoroutine(NewStand());
    }

    private void Update()
    {
        // Увеличиваем текущее время на время, прошедшее с последнего кадра
        _curentTime += Time.deltaTime;

        // Обновляем значение слайдера прогресса
        progressSlider.value = _curentTime / _storeTimer;
    }

    IEnumerator NewStand()
    {
        // Ждем _storeTimer секунд
        yield return new WaitForSeconds(_storeTimer);

        // Увеличиваем общее количество денег на baseCount, умноженное на количество магазинов
        totalMoney += baseCount * _buyShop.shopAmount;

        // Обновляем текстовое поле с количеством денег
        moneyText.text = totalMoney.ToString();

        // Сбрасываем текущее время
        _curentTime = 0;

        // Перезапускаем корутину
        StartCoroutine(NewStand());
    }
}
