using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StepScenarySO_", menuName = "Scriptable Objects/Scenary/Create Step Scenary SO")]
public class StepScenarySO : ScriptableObject
{
    public string title;
    public string description;
    public AnimationClip clipRun;
}
