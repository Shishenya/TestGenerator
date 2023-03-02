using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenaryButton : MonoBehaviour
{

    [SerializeField] private TMP_Text nameButton;
    private ScenarySO _scenarySO;

    public void InitButton(ScenarySO scenarySO)
    {
        _scenarySO = scenarySO;
        if (_scenarySO != null)
            nameButton.text = _scenarySO.nameScenary;
    }
}
