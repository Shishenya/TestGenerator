using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenaryTitlePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    private Scenary _scenary;

    private void OnEnable()
    {
        _scenary = ProjectService.Instance.CurrentScenary;
        titleText.text = _scenary.scenarySO.nameScenary;
    }

}
