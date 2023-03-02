using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectedPartUI : MonoBehaviour
{
    [SerializeField] private TMP_Text namePartText;
    private GameObject _selectedPartPanel;
    private SelectPart _selectPart;

    private void Awake()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        _selectedPartPanel = ProjectResources.Instance.selectedPartPanel;
    }

    private void OnEnable()
    {
        ShowSelectedPartPanel();
    }

    /// <summary>
    /// ��������� ���������� ������
    /// </summary>
    public void SetSelectPart(SelectPart selectPart)
    {

        if (_selectPart != null && selectPart != null) _selectPart.DisableSelect();

        _selectPart = selectPart;
        ShowOrHideSelectedPartPanel();
    }

    /// <summary>
    /// ���������� ��� �������� ������ � ���������� �������
    /// </summary>
    private void ShowOrHideSelectedPartPanel()
    {
        if (_selectPart == null)
        {
            HideSelectedPartPanel();
        }
        else
        {
            ShowSelectedPartPanel();
        }
    }

    /// <summary>
    /// �������� ������ � ���������� �������
    /// </summary>
    public void HideSelectedPartPanel()
    {
        _selectedPartPanel.SetActive(false);
    }

    /// <summary>
    /// ���������� ������ � �������� �������
    /// </summary>
    public void ShowSelectedPartPanel()
    {
        if (_selectPart != null)
        {
            _selectedPartPanel.SetActive(true);
            namePartText.text = _selectPart.gameObject.GetComponent<GeneratorPart>().generatorPartSO.namePart;
        } else
        {
            _selectedPartPanel.SetActive(false);
        }
    }
}
