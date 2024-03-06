using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Головной скрипт с instance-ссылкой, для простой работы с "основными" механиками и значениями.
    /// </summary>

    public static GameManager instance;

    //Awake для создания instance-ссылки
    private void Awake()
    {
        instance = this;
    }

    [Header("Added Currency per Click")]
    public float goldPerClick;
    public float silverPerClick;

    //[Header()]
    //

    //Функция сделана с расчётом на будущее - изменить количество
    //получаемой валюты при нажатии на кнопку.
    public void ChangeAmountPerClick(Currencies currencyType, float amount)
    {
        //функция через свитч для упрощения работы с возможным расширением кол-ва валют
        switch(currencyType)
        {
            case Currencies.Gold:
                {
                    goldPerClick += amount;
                    break;
                }
            case Currencies.Silver:
                {
                    silverPerClick += amount;
                    break;
                }
        }
    }
}
