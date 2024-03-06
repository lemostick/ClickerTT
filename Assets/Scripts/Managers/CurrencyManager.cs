using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//публичный список существующих в игре валют
public enum Currencies
{
    Gold,
    Silver
}

public class CurrencyManager : MonoBehaviour
{
    /// <summary>
    /// CurrencyManager - менеджер валют. Общий менеджер
    /// со ссылкой, существующий для упрощения работы с
    /// валютами из любой точки в скриптах.
    /// </summary>

    public static CurrencyManager instance;

    #region Currencies

    public List<Currency> currencies = new List<Currency>();

    #endregion


    //Awake для установления instance-ссылки.
    private void Awake()
    {
        instance = this;
    }

    //Функция добавления валюты. Реализована через поиск по переданному типу валюты currencyType.
    // - Функция вынесена отдельно от убавления валюты, т.к. могут содержаться модификаторы и множители,
    //   увеличивающие или уменьшающие получение валюты.
    public void AddCurrency(Currencies currencyType, float amount)
    {
        //ищем нужный тип валюты в списке
        var foundCurrency = currencies.Find(currency => currency.currencyType == currencyType);

        //добавляем валюту
        foundCurrency.AddCurrency(amount);

        //обновляем UI.
        UIManager.instance.mainScreen.UpdateValue(foundCurrency.currencyType);
    }

    //Функция убавления валюты. Реализована через поиск по переданному типу валюты currencyType.
    // - Функция вынесена отдельно, дабы убрать использование модификаторов упомянутых выше.
    public void DecreaseCurrency(Currencies currencyType, float amount)
    {
        //ищем нужный тип валюты в списке
        var foundCurrency = currencies.Find(currency => currency.currencyType == currencyType);

        //убавляем валюту
        foundCurrency.DecreaseCurrency(amount);

        //обновляем UI.
        UIManager.instance.mainScreen.UpdateValue(foundCurrency.currencyType);
    }

    public float FindCurrentAmount(Currencies currencyType)
    {
        //ищем нужный тип валюты в списке
        var foundCurrency = currencies.Find(currency => currency.currencyType == currencyType);

        //возвращаем текущее значение валюты
        return foundCurrency.currentAmount;
    }

    //на всякий, ещё раз - не одобряю наличие вызовов этой функции
    //в большом количестве. Я бы вывел это значение куда-то в магазин,
    //и апдейтил когда ты открываешь магазин (к примеру), ибо каждый раз
    //вызывать foreach, чтобы пробежаться и получить каждую переменную - 
    // - затратный вариант.
    public float FindOverallAmount()
    {
        //создаём временную переменную
        var overall = 0f;

        //получаем текущее количество каждой валюты в игре
        foreach(Currency curr in currencies)
        {
            overall += curr.currentAmount;
        }

        //возвращаем полученное количество.
        return overall;
    }
}

//Класс валюты, для дальнейшего расширения и изменения.
[System.Serializable]
public class Currency
{
    public Currencies currencyType;
    public float currentAmount;

    //возможный модификатор (как пример использования)
    //public float modAmount;

    public void AddCurrency(float amount)
    {
        //место для расширения и добавления модификаторов
        currentAmount += amount /* * modAmount */;
    }

    public void DecreaseCurrency(float amount)
    {
        currentAmount -= amount;
    }
}
