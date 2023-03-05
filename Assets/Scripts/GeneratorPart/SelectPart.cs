using UnityEngine;

public class SelectPart : MonoBehaviour
{
    private Material _selectedMaterial = null;
    private Material _defaultMaterial;
    private SwitcherStateService _switcherStateService;

    private bool _isSelected = false;
    private SelectedPartUI _selectedPartUI;
    private MeshRenderer _meshRenderer;

    public bool _searchGeneratorPartInParrent = false; // Искать generatorPart у родителя?
    [SerializeField] private MeshRenderer[] _relatedRenderer; // Связаные эелменты Renderer

    private void Start()
    {

        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMaterial = GetComponent<MeshRenderer>().material;

        LoadResources();
    }

    private void LoadResources()
    {
        _selectedPartUI = ProjectResources.Instance.selectedPartUI;
        _selectedMaterial = ProjectResources.Instance.selectedPartMaterial;
        _switcherStateService = ProjectResources.Instance.switcherStateService;
    }

    private void OnMouseDown()
    {

        if (_switcherStateService.GetState() == State.OverviewPartSelected || _switcherStateService.GetState() == State.SelectScenary) return;

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
        Material[] materials = _meshRenderer.materials;
        materials[0] = _defaultMaterial;
        materials[1] = _selectedMaterial;
        _meshRenderer.materials = materials;

        if (_relatedRenderer != null && _relatedRenderer.Length != 0)
        {
            foreach (MeshRenderer meshRenderer in _relatedRenderer)
            {
                Material[] materialsInRelatedRenderer = meshRenderer.materials;
                materialsInRelatedRenderer[0] = _defaultMaterial;
                materialsInRelatedRenderer[1] = _selectedMaterial;
                meshRenderer.materials = materialsInRelatedRenderer;
            }
        }
    }

    public void DisableMaterial()
    {
        Material[] materials = _meshRenderer.materials;
        materials[0] = _defaultMaterial;
        materials[1] = _defaultMaterial;
        _meshRenderer.materials = materials;

        if (_relatedRenderer != null && _relatedRenderer.Length != 0)
        {
            foreach (MeshRenderer meshRenderer in _relatedRenderer)
            {
                Material[] materialsInRelatedRenderer = meshRenderer.materials;
                materialsInRelatedRenderer[0] = _defaultMaterial;
                materialsInRelatedRenderer[1] = _defaultMaterial;
                meshRenderer.materials = materialsInRelatedRenderer;
            }
        }
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
