using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// ���� ������ ���������� ��� ��������� � ������ �� ����� UI ������������
    /// </summary>
    /// 
 
    #region startBlock
    public static UIManager instance;

    //Awake ��� �������� instance-������
    private void Awake()
    {
        instance = this;
    }

    //��������� ������� ������ ����� � ���� ��� screen.Initialize();, ��� �����.
    private void Start()
    {
        mainScreen.Initialize();
    }
    #endregion

    public UIHelper.MainScreen mainScreen;
}
