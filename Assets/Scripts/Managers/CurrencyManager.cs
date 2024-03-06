using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������� ������ ������������ � ���� �����
public enum Currencies
{
    Gold,
    Silver
}

public class CurrencyManager : MonoBehaviour
{
    /// <summary>
    /// CurrencyManager - �������� �����. ����� ��������
    /// �� �������, ������������ ��� ��������� ������ �
    /// �������� �� ����� ����� � ��������.
    /// </summary>

    public static CurrencyManager instance;

    #region Currencies

    public List<Currency> currencies = new List<Currency>();

    #endregion


    //Awake ��� ������������ instance-������.
    private void Awake()
    {
        instance = this;
    }

    //������� ���������� ������. ����������� ����� ����� �� ����������� ���� ������ currencyType.
    // - ������� �������� �������� �� ��������� ������, �.�. ����� ����������� ������������ � ���������,
    //   ������������� ��� ����������� ��������� ������.
    public void AddCurrency(Currencies currencyType, float amount)
    {
        //���� ������ ��� ������ � ������
        var foundCurrency = currencies.Find(currency => currency.currencyType == currencyType);

        //��������� ������
        foundCurrency.AddCurrency(amount);

        //��������� UI.
        UIManager.instance.mainScreen.UpdateValue(foundCurrency.currencyType);
    }

    //������� ��������� ������. ����������� ����� ����� �� ����������� ���� ������ currencyType.
    // - ������� �������� ��������, ���� ������ ������������� ������������� ���������� ����.
    public void DecreaseCurrency(Currencies currencyType, float amount)
    {
        //���� ������ ��� ������ � ������
        var foundCurrency = currencies.Find(currency => currency.currencyType == currencyType);

        //�������� ������
        foundCurrency.DecreaseCurrency(amount);

        //��������� UI.
        UIManager.instance.mainScreen.UpdateValue(foundCurrency.currencyType);
    }

    public float FindCurrentAmount(Currencies currencyType)
    {
        //���� ������ ��� ������ � ������
        var foundCurrency = currencies.Find(currency => currency.currencyType == currencyType);

        //���������� ������� �������� ������
        return foundCurrency.currentAmount;
    }

    //�� ������, ��� ��� - �� ������� ������� ������� ���� �������
    //� ������� ����������. � �� ����� ��� �������� ����-�� � �������,
    //� �������� ����� �� ���������� ������� (� �������), ��� ������ ���
    //�������� foreach, ����� ����������� � �������� ������ ���������� - 
    // - ��������� �������.
    public float FindOverallAmount()
    {
        //������ ��������� ����������
        var overall = 0f;

        //�������� ������� ���������� ������ ������ � ����
        foreach(Currency curr in currencies)
        {
            overall += curr.currentAmount;
        }

        //���������� ���������� ����������.
        return overall;
    }
}

//����� ������, ��� ����������� ���������� � ���������.
[System.Serializable]
public class Currency
{
    public Currencies currencyType;
    public float currentAmount;

    //��������� ����������� (��� ������ �������������)
    //public float modAmount;

    public void AddCurrency(float amount)
    {
        //����� ��� ���������� � ���������� �������������
        currentAmount += amount /* * modAmount */;
    }

    public void DecreaseCurrency(float amount)
    {
        currentAmount -= amount;
    }
}
