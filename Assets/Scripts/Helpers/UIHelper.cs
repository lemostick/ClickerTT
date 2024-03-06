using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class UIHelper
{
    /// <summary>
    /// UIHelper существует для создания отдельных "блоков" со всеми
    /// UI компонентами, и для дальнейшего вынесения блоков в UIManager
    /// для упрощения и универсализации работоспособности и обращения
    /// с UI компонентами.
    /// </summary>

    [System.Serializable]
    public class MainScreen
    {
        public GameObject mainObject;
        public TMP_Text goldCount;
        public TMP_Text silverCount;
        //хоть я и считаю это неправильным решением, выводить
        //общее кол-во ресурсов на главный экран...
        //так как это тестовое - ладно, но реализация вывода этого
        //на главный экран вместе с каждым изменением валюты затратна,
        //из-за чего и возникает "неправильность" решения. Не одобряю, в общем.
        public TMP_Text overallResourcesCount;

        public Button addGoldButton;
        public Button addSilverButton;

        //функция-инициализатор основного экрана (mainScreen)
        public void Initialize()
        {
            goldCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindCurrentAmount(Currencies.Gold));
            silverCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindCurrentAmount(Currencies.Silver));
            overallResourcesCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindOverallAmount());

            //overallResourcesCount.text = FormatHelper.FormatNumber()
        }

        //функция изменения отображаемого числа валюты. Реализована через свитч для дальнейшего расширения.
        public void UpdateValue(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.Gold:
                    {
                        goldCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindCurrentAmount(Currencies.Gold));

                        break;
                    }
                case Currencies.Silver:
                    {
                        silverCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindCurrentAmount(Currencies.Silver));

                        break;
                    }
            }

            //ох не нравится мне, как это работает, но ТЗ требует, я сделал.
            overallResourcesCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindOverallAmount());
        }
    }
}
