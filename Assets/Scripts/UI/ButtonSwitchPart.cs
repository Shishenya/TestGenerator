using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSwitchPart : MonoBehaviour
{

    [SerializeField] TMP_Text nameButton;
    private GeneratorPart _generatorPart;
    private OverviewPart _overviewPart;
    private SwitcherStateService _switcherStateService;
    private SelectedPartUI _selectedPartUI;
    private MainCanvasUI _mainCanvasUI;


    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        _overviewPart = ProjectResources.Instance.overviewPart;
        _switcherStateService = ProjectResources.Instance.switcherStateService;
        _selectedPartUI = ProjectResources.Instance.selectedPartUI;
        _mainCanvasUI = ProjectResources.Instance.mainCanvasUI;
    }
    public void InitButton(GeneratorPart generatorPart)
    {
        _generatorPart = generatorPart;
        nameButton.text = generatorPart.generatorPartSO.namePart;
    }

    /// <summary>
    /// Показать конкретную деталь
    /// </summary>
    public void ViewCurrentPart()
    {

        _switcherStateService.SetState(State.OverviewPart);
        _mainCanvasUI.ShowPanelsByState();

        _overviewPart.currentViewPart = _generatorPart.gameObject;
        _overviewPart.OverviewCurrentEnablePart();
    }
}
