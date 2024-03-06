using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class FormatHelper
{
    /// <summary>
    /// FormatHelper - "помощник" форматирования. Здесь все функции для работы и изменения текста.
    /// </summary>

    //Привести число number к общему формату (1 000 000...)
    public static string FormatNumber(float number)
    {
        return number == 0 ? "0" : number.ToString("##,#").Replace(",", " ");
    }

    //получить float из string формата 1 000 000..., который задаётся выше
    public static float ReturnFromString(string input)
    {
        var floatValue = 0f;

        input.Replace(" ", "");

        float.TryParse(input, out floatValue);

        return floatValue;
    }

    //Убрать пробел в начале string поля input. Для избавления от багов.
    public static string FormatString(string input)
    {
        if (input.StartsWith(" "))
        {
            input.Remove(0);
        }

        return CheckIfInputIsEmpty(input);
    }

    //Проверка, не является ли input пустым полем.
    public static string CheckIfInputIsEmpty(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "Empty";
        else
            return input;
    }

    //простая функция для добавления пробела в конце текстового поля.
    public static string AddSpaceOnEnd(string input)
    {
        return input + " ";
    }
}
