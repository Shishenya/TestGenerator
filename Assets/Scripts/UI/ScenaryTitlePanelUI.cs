using UnityEngine;
using TMPro;

public class ScenaryTitlePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    private Scenary _scenary;

    private void OnEnable()
    {
        _scenary = ProjectService.Instance.CurrentScenary;
        if (_scenary != null)
            titleText.text = _scenary.scenarySO.nameScenary;
    }

}
