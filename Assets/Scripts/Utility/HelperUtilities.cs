using UnityEngine;

public static class HelperUtilities
{
    /// <summary>
    /// �������� �� ������ ������
    /// </summary>
    public static bool ValidateCheckEmptyString(Object thisObject, string fieldName, string stringToCheck)
    {
        if (stringToCheck == "")
        {
            Debug.Log(fieldName + " ������ ������ � ������� " + thisObject.name.ToString());
            return true;
        }
        return false;
    }

    /// <summary>
    /// �������� �� ������ ��������
    /// </summary>
    public static bool ValidateCheckNullValue(Object thisObject, string fieldName, UnityEngine.Object objectToCheck)
    {
        if (objectToCheck == null)
        {
            Debug.Log(fieldName + " ������ �������� � ������� " + thisObject.name.ToString());
            return true;
        }
        return false;
    }
}
