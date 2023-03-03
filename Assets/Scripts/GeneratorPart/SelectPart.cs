using UnityEngine;

public class SelectPart : MonoBehaviour
{
    private Material _selectedMaterial = null;
    private Material _defaultMaterial;
    private bool _isSelected = false;
    private SelectedPartUI _selectedPartUI;
    private MeshRenderer _meshRenderer;
    [SerializeField] private bool _searchMetarialInChildren = false;
    [SerializeField] private MeshRenderer _childrenRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_meshRenderer != null)
        {
            _defaultMaterial = GetComponent<MeshRenderer>().material;
        }
        else
        {
            if (_searchMetarialInChildren)
            {
                _meshRenderer = _childrenRenderer;
                _defaultMaterial = _childrenRenderer.material;
            }
        }

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
        // _meshRenderer.material = _selectedMaterial;

        Material[] materials = transform.GetComponent<MeshRenderer>().materials;
        materials[0] = _defaultMaterial;
        materials[1] = _selectedMaterial;
        transform.GetComponent<MeshRenderer>().materials = materials;

        // _meshRenderer.materials[1] = _selectedMaterial;
    }

    public void DisableMaterial()
    {
        // _meshRenderer.material = _defaultMaterial;
        //_meshRenderer.materials[1] = _defaultMaterial;
        Material[] materials = transform.GetComponent<MeshRenderer>().materials;
        materials[0] = _defaultMaterial;
        materials[1] = _defaultMaterial;
        transform.GetComponent<MeshRenderer>().materials = materials;
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
