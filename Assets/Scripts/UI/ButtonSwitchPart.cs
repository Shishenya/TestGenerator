using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSwitchPart : MonoBehaviour
{

    [SerializeField] TMP_Text nameButton;
    private GeneratorPart _generatorPart;
    private OverviewPart _overviewPart;


    private void Start()
    {
        LoadResources();
    }
    private void LoadResources()
    {
        _overviewPart = ProjectResources.Instance.overviewPart;
    }
    public void InitButton(GeneratorPart generatorPart)
    {
        _generatorPart = generatorPart;
        nameButton.text = generatorPart.generatorPartSO.namePart;
    }

    public void ViewCurrentPart()
    {
        ProjectResources.Instance.mainCanvasUI.HideSwitchPartsPanelClick();
        ProjectResources.Instance.mainCanvasUI.ShowOverviewPartPanel();

        _overviewPart.currentViewPart = _generatorPart.gameObject;
        _overviewPart.OverviewCurrentEnablePart();
    }
}
