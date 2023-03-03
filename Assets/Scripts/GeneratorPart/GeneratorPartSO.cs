using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GeneratorPartSO_", menuName = "Scriptable Objects/Generator Part/Create Generator Part SO")]
public class GeneratorPartSO : ScriptableObject
{
    public string namePart;
    public Vector3 defaultPosition;
    public Vector3 disassemblyPosition;
}
