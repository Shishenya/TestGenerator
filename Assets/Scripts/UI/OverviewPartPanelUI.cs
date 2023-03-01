using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverviewPartPanelUI : MonoBehaviour
{
    const string title = "Обзор составной части: ";
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private OverviewPart _overviewPart;
    [SerializeField] private GameObject _switchPartsPanel;

    public static OverviewPartPanelUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        _overviewPart.showPartEvent += UpdateTitle;
        _overviewPart.hidePartEvent += UpdateTitle;
    }

    private void UpdateTitle(GameObject partGenetator)
    {
        if (partGenetator != null)
        {
            if (partGenetator.GetComponent<GeneratorPart>() != null)
            {
                string namePart = partGenetator.GetComponent<GeneratorPart>().generatorPartSO.namePart;
                _titleText.text = $"{title}{namePart}";
            }
        }
        else
        {
            _titleText.text = title;
        }
    }

    /// <summary>
    /// Выход из состояния обзора отдельной части
    /// </summary>
    public void ReturnButtonClick()
    {
        _overviewPart.ReturnClick();
    }

    public void ShowSwitchPartsPanelClick()
    {
        _switchPartsPanel.SetActive(true);
    }

    public void HideSwitchPartsPanelClick()
    {
        _switchPartsPanel.SetActive(false);
    }

}
