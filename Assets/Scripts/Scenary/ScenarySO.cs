using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenarySO_", menuName = "Scriptable Objects/Scenary/Create Scenary SO")]
public class ScenarySO : ScriptableObject
{
    public string nameScenary;
    public StepScenarySO[] stepsScenary;

    public AnimationClip defaultPosition;

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(nameScenary), nameScenary);
        HelperUtilities.ValidateCheckNullValue(this, nameof(defaultPosition), defaultPosition);
    }
#endif
    #endregion
}
