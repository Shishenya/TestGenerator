using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSwitchPart : MonoBehaviour
{

    [SerializeField] TMP_Text nameButton;
    private GeneratorPart _generatorPart;
    public void InitButton(GeneratorPart generatorPart)
    {
        _generatorPart = generatorPart;
        nameButton.text = generatorPart.generatorPartSO.namePart;
    }

    public void ViewCurrentPart()
    {
        OverviewPart.Instance.currentViewPart = _generatorPart.gameObject;
        OverviewPart.Instance.OverviewCurrentEnablePart();
        OverviewPartPanelUI.Instance.HideSwitchPartsPanelClick();
    }
}
