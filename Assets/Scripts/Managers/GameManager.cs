using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �������� ������ � instance-�������, ��� ������� ������ � "���������" ���������� � ����������.
    /// </summary>

    public static GameManager instance;

    //Awake ��� �������� instance-������
    private void Awake()
    {
        instance = this;
    }

    [Header("Added Currency per Click")]
    public float goldPerClick;
    public float silverPerClick;

    //[Header()]
    //

    //������� ������� � �������� �� ������� - �������� ����������
    //���������� ������ ��� ������� �� ������.
    public void ChangeAmountPerClick(Currencies currencyType, float amount)
    {
        //������� ����� ����� ��� ��������� ������ � ��������� ����������� ���-�� �����
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
