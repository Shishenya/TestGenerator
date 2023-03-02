using UnityEngine;

public class SelectPart : MonoBehaviour
{
    [SerializeField] private Material _selectedMaterial = null;
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

    /// <summary>
    /// Включаем выделение
    /// </summary>
    private void EnableSelect()
    {
        GetComponent<MeshRenderer>().material = _selectedMaterial;
        _selectedPartUI.SetSelectPart(this);
    }

    /// <summary>
    /// Отключаем выделение
    /// </summary>
    public void DisableSelect()
    {
        GetComponent<MeshRenderer>().material = _defaultMaterial;
        _selectedPartUI.SetSelectPart(null);
    }
}
