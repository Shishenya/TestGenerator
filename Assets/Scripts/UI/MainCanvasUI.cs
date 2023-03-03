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
    private GameObject _scenaryPanel;
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
        _scenaryPanel = ProjectResources.Instance.scenaryPanel;
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
        _scenaryPanel.SetActive(false);
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
    /// �������� ������ ������/��������
    /// </summary>
    public void ShowAssemblyPanel()
    {
        _assemblyPanel.SetActive(true);
    }

    /// <summary>
    /// ������ ������ ������ ��������
    /// </summary>
    public void HideAssemblyPanel()
    {
        _assemblyPanel.SetActive(false);
    }

    /// <summary>
    /// �������� ������ �� ���������
    /// </summary>
    public void ShowScenaryPanel()
    {
        _scenaryPanel.SetActive(true);
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
    /// ������ "�������� ��������"
    /// </summary>
    public void ClickButtonResetScenary()
    {
        ProjectService.Instance.ResetScenary();
        _switcherStateService.SetState(State.NonRunScenary);
        ShowPanelsByState();
    }

    /// <summary>
    /// ������ "��������� ��������"
    /// </summary>
    public void ClickButtonRunScenary()
    {
        _switcherStateService.SetState(State.RunScenary);
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
                DisableAllPanel();
                ShowAssemblyPanel();
                ShowSelectPartPanel();
                ShowScenaryPanel();
                break;
            default:
                DisableAllPanel();
                ShowStartPanel();
                break;
        }


    }

}
