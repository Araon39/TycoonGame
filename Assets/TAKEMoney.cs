using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TAKEMoney : MonoBehaviour
{
    // ������� ���������� �����, ����������� ������ ����
    [SerializeField] private int baseCount = 5;

    // ����� ���������� �����
    public float totalMoney = 2;

    // ��������� ������� UI ��� ����������� ���������� �����
    public Text moneyText;

    // ������ �� ��������� BuyShop
    private BuyShop _buyShop;

    // ������� ��� ����������� ���������
    [SerializeField] private Slider progressSlider;

    // ����� �������� ����� �������
    private float _storeTimer = 2f;

    // ������� �����, ��������� � ������ �����
    [SerializeField] private float _curentTime;

    void Start()
    {
        // ������� ��������� BuyShop �� ������� "NewStandPanel"
        _buyShop = GameObject.Find("NewStandPanel").GetComponent<BuyShop>();

        // ��������� �������� NewStand
        StartCoroutine(NewStand());
    }

    private void Update()
    {
        // ����������� ������� ����� �� �����, ��������� � ���������� �����
        _curentTime += Time.deltaTime;

        // ��������� �������� �������� ���������
        progressSlider.value = _curentTime / _storeTimer;
    }

    IEnumerator NewStand()
    {
        // ���� _storeTimer ������
        yield return new WaitForSeconds(_storeTimer);

        // ����������� ����� ���������� ����� �� baseCount, ���������� �� ���������� ���������
        totalMoney += baseCount * _buyShop.shopAmount;

        // ��������� ��������� ���� � ����������� �����
        moneyText.text = totalMoney.ToString();

        // ���������� ������� �����
        _curentTime = 0;

        // ������������� ��������
        StartCoroutine(NewStand());
    }
}
