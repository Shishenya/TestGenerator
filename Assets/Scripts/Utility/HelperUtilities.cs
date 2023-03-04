using UnityEngine;

public static class HelperUtilities
{
    /// <summary>
    /// Проверка на пустую строку
    /// </summary>
    public static bool ValidateCheckEmptyString(Object thisObject, string fieldName, string stringToCheck)
    {
        if (stringToCheck == "")
        {
            Debug.Log(fieldName + " пустая строка в объекте " + thisObject.name.ToString());
            return true;
        }
        return false;
    }

    /// <summary>
    /// Проверка на пустое значение
    /// </summary>
    public static bool ValidateCheckNullValue(Object thisObject, string fieldName, UnityEngine.Object objectToCheck)
    {
        if (objectToCheck == null)
        {
            Debug.Log(fieldName + " пустое значение в объекте " + thisObject.name.ToString());
            return true;
        }
        return false;
    }
}
