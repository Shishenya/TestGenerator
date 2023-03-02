using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasUI : MonoBehaviour
{
    private GameObject _switchPartsPanel;
    private GameObject _overviewPartPanel;
    private GameObject _assemblyPanel;
    private GameObject _startPanel;

    private void Start()
    {
        LoadResourves();
    }

    private void LoadResourves()
    {
        _switchPartsPanel = ProjectResources.Instance.switchPartPanel;
        _overviewPartPanel = ProjectResources.Instance.overviewPartPanel;
        _assemblyPanel = ProjectResources.Instance.assemblyPanel;
        _startPanel = ProjectResources.Instance.startPanel;
    }

    private void DisableAllPanel()
    {
        _switchPartsPanel.SetActive(false);
        _overviewPartPanel.SetActive(false);
        _assemblyPanel.SetActive(false);
        _startPanel.SetActive(false);
    }

    /// <summary>
    /// Показать панель с выбором отдельной детали
    /// </summary>
    public void ShowSwitchPartsPanelClick()
    {
        // DisableAllPanel();
        _switchPartsPanel.SetActive(true);
    }

    /// <summary>
    /// Скрыть панешль с выбором отдельной детали
    /// </summary>
    public void HideSwitchPartsPanelClick()
    {
        _switchPartsPanel.SetActive(false);
    }

    /// <summary>
    /// Показать верхную панель с выбором деталей
    /// </summary>
    public void ShowOverviewPartPanel()
    {
        DisableAllPanel();
        _overviewPartPanel.SetActive(true);
    }

    /// <summary>
    /// Скрыть верхную панель с выбором деталей
    /// </summary>
    public void HideOverviewPartPanel()
    {
        _overviewPartPanel.SetActive(false);
    }
}
