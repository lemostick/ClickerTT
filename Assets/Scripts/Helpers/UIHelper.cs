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
    /// UIHelper ���������� ��� �������� ��������� "������" �� �����
    /// UI ������������, � ��� ����������� ��������� ������ � UIManager
    /// ��� ��������� � ��������������� ����������������� � ���������
    /// � UI ������������.
    /// </summary>

    [System.Serializable]
    public class MainScreen
    {
        public GameObject mainObject;
        public TMP_Text goldCount;
        public TMP_Text silverCount;
        //���� � � ������ ��� ������������ ��������, ��������
        //����� ���-�� �������� �� ������� �����...
        //��� ��� ��� �������� - �����, �� ���������� ������ �����
        //�� ������� ����� ������ � ������ ���������� ������ ��������,
        //��-�� ���� � ��������� "��������������" �������. �� �������, � �����.
        public TMP_Text overallResourcesCount;

        public Button addGoldButton;
        public Button addSilverButton;

        //�������-������������� ��������� ������ (mainScreen)
        public void Initialize()
        {
            goldCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindCurrentAmount(Currencies.Gold));
            silverCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindCurrentAmount(Currencies.Silver));
            overallResourcesCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindOverallAmount());

            //overallResourcesCount.text = FormatHelper.FormatNumber()
        }

        //������� ��������� ������������� ����� ������. ����������� ����� ����� ��� ����������� ����������.
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

            //�� �� �������� ���, ��� ��� ��������, �� �� �������, � ������.
            overallResourcesCount.text = FormatHelper.FormatNumber(CurrencyManager.instance.FindOverallAmount());
        }
    }
}
