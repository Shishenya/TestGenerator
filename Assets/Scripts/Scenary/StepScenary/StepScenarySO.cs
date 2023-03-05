using UnityEngine;

[CreateAssetMenu(fileName = "StepScenarySO_", menuName = "Scriptable Objects/Scenary/Create Step Scenary SO")]
public class StepScenarySO : ScriptableObject
{
    public string title;
    public string description;
    public AnimationClip clipRun;
    public bool clipShouldNotBe = false; // в текущем шаге не требуется клип

    public GeneratorPartSO[] needPartClickToClipShow; // по какой части надо кликнуть, чтобы пошла анимация

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(title), title);
        HelperUtilities.ValidateCheckEmptyString(this, nameof(description), description);
        if (!clipShouldNotBe)
            HelperUtilities.ValidateCheckNullValue(this, nameof(clipRun), clipRun);
    }
#endif
    #endregion
}
