using UnityEngine;

public class SelectPart : MonoBehaviour
{
    private Material _selectedMaterial = null;
    private Material _defaultMaterial;
    private bool _isSelected = false;
    private SelectedPartUI _selectedPartUI;

    private void Start()
    {
        _defaultMaterial = GetComponent<MeshRenderer>().material;

        LoadResources();
    }

    private void LoadResources()
    {
        _selectedPartUI = ProjectResources.Instance.selectedPartUI;
        _selectedMaterial = ProjectResources.Instance.selectedPartMaterial;
    }

    private void OnMouseDown()
    {
        if (_isSelected)
        {
            DisableSelect();
        }
        else
        {
            EnableSelect();
        }

        _isSelected = !_isSelected;
    }

    public void EnableMaterial()
    {
        GetComponent<MeshRenderer>().material = _selectedMaterial;
    }

    public void DisableMaterial()
    {
        GetComponent<MeshRenderer>().material = _defaultMaterial;
    }

    /// <summary>
    /// Включаем выделение
    /// </summary>
    private void EnableSelect()
    {
        _selectedPartUI.SetSelectPart(this);
    }

    /// <summary>
    /// Отключаем выделение
    /// </summary>
    public void DisableSelect()
    {
        _selectedPartUI.SetSelectPart(this);
    }
}
