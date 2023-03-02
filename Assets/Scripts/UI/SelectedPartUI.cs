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
    /// Установка выделенной детали
    /// </summary>
    public void SetSelectPart(SelectPart selectPart)
    {

        if (_selectPart != null && _selectPart == selectPart)
        {
            _selectPart.DisableMaterial();
            _selectPart = null;
        }
        else
        {
            if (_selectPart != null) _selectPart.DisableMaterial();
            _selectPart = selectPart;
            _selectPart.EnableMaterial();
        }

        ShowOrHideSelectedPartPanel();
    }

    /// <summary>
    /// Отображает или скрывает панель с выделенной деталью
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
    /// Скрывает панель с выделенной деталью
    /// </summary>
    public void HideSelectedPartPanel()
    {
        _selectedPartPanel.SetActive(false);
    }

    /// <summary>
    /// Показывает панель с выбраной деталью
    /// </summary>
    public void ShowSelectedPartPanel()
    {
        if (_selectPart != null)
        {
            _selectedPartPanel.SetActive(true);
            namePartText.text = _selectPart.gameObject.GetComponent<GeneratorPart>().generatorPartSO.namePart;
        }
        else
        {
            _selectedPartPanel.SetActive(false);
        }
    }
}
