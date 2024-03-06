using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Этот скрипт существует для поддержки и работы со всеми UI компонентами
    /// </summary>
    /// 
 
    #region startBlock
    public static UIManager instance;

    //Awake для создания instance-ссылки
    private void Awake()
    {
        instance = this;
    }

    //стартовая функция должна иметь в себе все screen.Initialize();, при нужде.
    private void Start()
    {
        mainScreen.Initialize();
    }
    #endregion

    public UIHelper.MainScreen mainScreen;
}
