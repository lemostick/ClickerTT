using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCurrencyButton : MonoBehaviour
{
    /// <summary>
    /// Скрипт вешается на кнопку и делает из неё (в любом случае)
    /// кнопку для получения валюты за клик.
    /// </summary>

    public Currencies currencyType;
    public Button thisButton;

    //При загрузке убрать все функции с кнопки и добавить функцию "добавить валюту за клик"
    private void Awake()
    {
        //проверка "на дурака", если забыл указать кнопку в инспекторе.
        if (thisButton == null)
            thisButton = GetComponent<Button>();

        //удалить все функции с кнопки
        thisButton.onClick.RemoveAllListeners();

        //добавить функцию AddCurrency на кнопку.
        thisButton.onClick.AddListener(AddCurrency);
    }

    //Функция "добавить валюту", вынесена для простоты изменения.
    //Реализована через свитч для дальнейшей возможности расширения кол-ва валют.
    void AddCurrency()
    {
        switch(currencyType)
        {
            case Currencies.Gold:
                {
                    CurrencyManager.instance.AddCurrency(currencyType, GameManager.instance.goldPerClick);
                    break;
                }
            case Currencies.Silver:
                {
                    CurrencyManager.instance.AddCurrency(currencyType, GameManager.instance.silverPerClick);
                    break;
                }
        }
    }
}
