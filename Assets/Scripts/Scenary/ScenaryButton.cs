using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenaryButton : MonoBehaviour
{

    [SerializeField] private TMP_Text nameButton;
    private ScenarySO _scenarySO;
    private MainCanvasUI _mainCanvasUI;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        _mainCanvasUI = ProjectResources.Instance.mainCanvasUI;
    }

    public void InitButton(ScenarySO scenarySO)
    {
        _scenarySO = scenarySO;
        if (_scenarySO != null)
            nameButton.text = _scenarySO.nameScenary;
    }

    /// <summary>
    ///  нопка "запустить сценарий"
    /// </summary>
    public void ClickButtonScenaryRun()
    {
        ProjectService.Instance.RunScenary(_scenarySO);
        _mainCanvasUI.ClickButtonRunScenary();
    }
}
