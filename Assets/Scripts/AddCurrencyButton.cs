using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCurrencyButton : MonoBehaviour
{
    /// <summary>
    /// ������ �������� �� ������ � ������ �� �� (� ����� ������)
    /// ������ ��� ��������� ������ �� ����.
    /// </summary>

    public Currencies currencyType;
    public Button thisButton;

    //��� �������� ������ ��� ������� � ������ � �������� ������� "�������� ������ �� ����"
    private void Awake()
    {
        //�������� "�� ������", ���� ����� ������� ������ � ����������.
        if (thisButton == null)
            thisButton = GetComponent<Button>();

        //������� ��� ������� � ������
        thisButton.onClick.RemoveAllListeners();

        //�������� ������� AddCurrency �� ������.
        thisButton.onClick.AddListener(AddCurrency);
    }

    //������� "�������� ������", �������� ��� �������� ���������.
    //����������� ����� ����� ��� ���������� ����������� ���������� ���-�� �����.
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
