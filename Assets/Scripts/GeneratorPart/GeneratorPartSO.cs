using UnityEngine;

[CreateAssetMenu(fileName ="GeneratorPartSO_", menuName = "Scriptable Objects/Generator Part/Create Generator Part SO")]
public class GeneratorPartSO : ScriptableObject
{
    public string namePart;
    public Vector3 defaultPosition;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(namePart), namePart);
    }
#endif
    #endregion
}
