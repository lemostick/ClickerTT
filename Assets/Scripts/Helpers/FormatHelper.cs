using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class FormatHelper
{
    /// <summary>
    /// FormatHelper - "��������" ��������������. ����� ��� ������� ��� ������ � ��������� ������.
    /// </summary>

    //�������� ����� number � ������ ������� (1 000 000...)
    public static string FormatNumber(float number)
    {
        return number == 0 ? "0" : number.ToString("##,#").Replace(",", " ");
    }

    //�������� float �� string ������� 1 000 000..., ������� ������� ����
    public static float ReturnFromString(string input)
    {
        var floatValue = 0f;

        input.Replace(" ", "");

        float.TryParse(input, out floatValue);

        return floatValue;
    }

    //������ ������ � ������ string ���� input. ��� ���������� �� �����.
    public static string FormatString(string input)
    {
        if (input.StartsWith(" "))
        {
            input.Remove(0);
        }

        return CheckIfInputIsEmpty(input);
    }

    //��������, �� �������� �� input ������ �����.
    public static string CheckIfInputIsEmpty(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "Empty";
        else
            return input;
    }

    //������� ������� ��� ���������� ������� � ����� ���������� ����.
    public static string AddSpaceOnEnd(string input)
    {
        return input + " ";
    }
}
