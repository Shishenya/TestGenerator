using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasUI : MonoBehaviour
{
    private GameObject _switchPartsPanel;
    private GameObject _overviewPartPanel;
    private GameObject _assemblyPanel;
    private GameObject _startPanel;
    private GameObject _selectedScenaryPanel;
    private GameObject _selectedPartPanel;
    private SelectedPartUI _selectedPartUI;

    private SwitcherStateService _switcherStateService;

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
        _selectedScenaryPanel = ProjectResources.Instance.selectedScenaryPanel;
        _selectedPartPanel = ProjectResources.Instance.selectedPartPanel;
        _switcherStateService = ProjectResources.Instance.switcherStateService;
        _selectedPartUI = ProjectResources.Instance.selectedPartUI;
    }

    private void DisableAllPanel()
    {
        _switchPartsPanel.SetActive(false);
        _overviewPartPanel.SetActive(false);
        _assemblyPanel.SetActive(false);
        _startPanel.SetActive(false);
        _selectedScenaryPanel.SetActive(false);
    }

    private void ShowStartPanel()
    {
        _startPanel.SetActive(true);
    }

    /// <summary>
    /// �������� ������ � ������� ��������� ������
    /// </summary>
    public void ShowSwitchPartsPanelClick()
    {
        _switchPartsPanel.SetActive(true);
    }

    /// <summary>
    /// ������ ������ � ������� ��������� ������
    /// </summary>
    public void HideSwitchPartsPanelClick()
    {
        // _startPanel.SetActive(true);
        _switchPartsPanel.SetActive(false);
    }

    /// <summary>
    /// �������� ������� ������ � ������� �������
    /// </summary>
    public void ShowOverviewPartPanel()
    {        
        _overviewPartPanel.SetActive(true);
    }

    /// <summary>
    /// ������ ������� ������ � ������� �������
    /// </summary>
    public void HideOverviewPartPanel()
    {
        _overviewPartPanel.SetActive(false);
    }

    /// <summary>
    /// ��������� ������ � ������� ��������
    /// </summary>
    public void ShowSelectedScenaryPanel()
    {
        _selectedScenaryPanel.SetActive(true);
    }

    /// <summary>
    /// �������� ������ � ������� ��������
    /// </summary>
    public void HideSelectedScenaryPanel()
    {
        _switcherStateService.SetState(State.NonRunScenary);
        ShowPanelsByState();
    }

    /// <summary>
    /// �������� ������ � ���������� �������
    /// </summary>
    public void ShowSelectPartPanel()
    {
        _selectedPartPanel.SetActive(true);
    }

    /// <summary>
    /// ������ ������ � ��������� �������
    /// </summary>
    public void HideSelectPartPanel()
    {
        _selectedPartPanel.SetActive(false);
    }

    /// <summary>
    /// ������ "������� ��������"
    /// </summary>
    public void ClickButtonSelectScenary()
    {
        _switcherStateService.SetState(State.SelectScenary);
        ShowPanelsByState();
    }

    /// <summary>
    /// ������ "������� ������ ������ ���������"
    /// </summary>
    public void ClickButtonCloseSelectScenary()
    {
        _switcherStateService.SetState(State.NonRunScenary);
        ShowPanelsByState();
    }

    /// <summary>
    /// ������ "������� ���������� ������"
    /// </summary>
    public void ClickButtonSelectPart()
    {
        _switcherStateService.SetState(State.OverviewPartSelected);
        ShowPanelsByState();
    }

    /// <summary>
    /// ���������� ������ � ����������� �� �������
    /// </summary>
    public void ShowPanelsByState()
    {
        State state = _switcherStateService.GetState();

        switch (state)
        {
            case State.NonRunScenary: // ��� ��������
                DisableAllPanel(); 
                ShowStartPanel();
                ShowSelectPartPanel();
                break;
            case State.OverviewPart: // ������������� ��������� ������
                DisableAllPanel();
                ShowOverviewPartPanel();
                HideSelectPartPanel();
                break;
            case State.OverviewPartSelected: // �������� ���� ������ ������
                ShowSwitchPartsPanelClick();
                break;
            case State.SelectScenary: // �������� ���� ������ ��������
                DisableAllPanel();
                ShowStartPanel();
                HideSelectPartPanel();
                ShowSelectedScenaryPanel();
                break;
            case State.RunScenary: // ������� ��������
                break;
            default:
                DisableAllPanel();
                ShowStartPanel();
                break;
        }


    }

}
