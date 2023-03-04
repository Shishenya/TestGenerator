using UnityEngine;

public class GeneratorPart : MonoBehaviour
{
    [SerializeField] private GeneratorPartSO _generatorPartSO;
    public bool isOverviewPart = false;

    public GeneratorPartSO generatorPartSO { get => _generatorPartSO;  }
}
