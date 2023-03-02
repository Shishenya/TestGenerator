using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPartUI : MonoBehaviour
{
    private GameObject _selectedPartPanel;
    private SelectPart _selectPart;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        _selectedPartPanel = ProjectResources.Instance.selectedPartPanel;
    }

    /// <summary>
    /// Установка выделенной детали
    /// </summary>
    public void SetSelectPart(SelectPart selectPart)
    {
        if (_selectPart != null && selectPart != null) _selectPart.DisableSelect();

        _selectPart = selectPart;
        ShowOrHideSelectedPartPanel();
    }

    /// <summary>
    /// Отображает или скрывает панель с выделенной деталью
    /// </summary>
    private void ShowOrHideSelectedPartPanel()
    {
        if (_selectPart == null)
        {
            _selectedPartPanel.SetActive(false);
        }
        else
        {
            _selectedPartPanel.SetActive(true);
        }
    }
}
